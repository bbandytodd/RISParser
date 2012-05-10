using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Xml;

using RISParser.Model;

namespace RISParser
{
    /// <summary>
    /// RISParser is a library for parsing RIS data files (http://en.wikipedia.org/wiki/RIS_(file_format)) in .NET.
    /// It will parse a RIS file and return a List of IRISPublication objects representating the parsed data.
    /// 
    /// Author: Andy Todd
    /// Date: 9/05/2012
    /// </summary>
    public class RISParser
    {

        private XmlDocument _xmlDoc = null;
        //--these fields are currently manually parsed (as opposed to using reflection)
        protected string[] _manualFields = new string[] {"KW","TY","AU" };
        //--these fields may contain multiple elements in a series, e.g. AU followed by A1, A2 etc.
        protected string[] _seriesTypes = new string[] {"AU" };

        /// <summary>
        /// Creates a new instance of the RISParser
        /// </summary>
        public RISParser()
        {
            //--the mappings xmldocument tells the app how to map RIS fields onto the model
            _xmlDoc = new XmlDocument();
            using(Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("RISParser.res.mappings.xml"))
            using (StreamReader reader = new StreamReader(s))
            {
                _xmlDoc.LoadXml(reader.ReadToEnd());
            }
        }

        /// <summary>
        /// Parses the RIS file at the specified path and returns a list of IRISPublication objects representing the publications held within the RIS file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<IRISPublication> ParseRISDocument(string path)
        {
            List<IRISPublication> pubs = null;
            
            if (!File.Exists(path))
            {
                throw new ArgumentException("The supplied path is invalid");
            }
            else
            {
                using(FileStream stream = new FileStream(path, FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string fileContents = reader.ReadToEnd();
                    pubs = ParseDocInternal(fileContents);
                }
            }
            

            return pubs;
        }

        /// <summary>
        /// Performs the parsing using the fileContents supplied.
        /// </summary>
        /// <param name="fileContents"></param>
        /// <param name="pub"></param>
        protected List<IRISPublication> ParseDocInternal(string fileContents)
        {
            List<IRISPublication> pubs = new List<IRISPublication>();
            
            //--each entry in the RIS file is split on double CRLF so split on that
            string[] entries = Regex.Split(fileContents, "\r\n\r\n");

            foreach (string s in entries)
            {
                IRISPublication pub = ParsePublication(s);
                pubs.Add(pub);
            }

            return pubs;
        }

        /// <summary>
        /// Parses a publication, extracting it's fields
        /// </summary>
        /// <param name="markup"></param>
        /// <returns></returns>
        protected IRISPublication ParsePublication(string markup)
        {
            BaseRISPublication pub = new BaseRISPublication();

            //--each field in the publication is separated by \r\n
            string[] fields = Regex.Split(markup, "\r\n");
            foreach(string field in fields) 
            {
                //--each field is formatted FC - FV where FC is a field code and FV is the value
                string[] fieldArray = Regex.Split(field, " - ");
                if (fieldArray.Count() == 2)
                {
                    ParseField(fieldArray, pub);
                }
                else
                {
                    //TODO invalid or empty field, should probably log this
#warning Empty else block
                }
            }

            return pub;
        }

        /// <summary>
        /// Parses a field to get it's type and value
        /// </summary>
        /// <param name="fieldArray"></param>
        /// <param name="pub"></param>
        protected void ParseField(string[] fieldArray,  IRISPublication pub)
        {
            string fieldCode = fieldArray[0];
            string fieldValue = fieldArray[1];

            XmlNode mappingNode = _xmlDoc.SelectSingleNode("mappings/mapping[@source='" + fieldCode + "']");
            if (mappingNode != null || _manualFields.Contains(fieldCode))
            {

                //--set single valued types easily
                if (!_manualFields.Contains(fieldCode))
                {
                    string destination = mappingNode.SelectSingleNode("@destination").InnerText;
                    string destType = mappingNode.SelectSingleNode("@type").InnerText;

                    if (destType == "string")
                    {
                        typeof(IRISPublication).GetProperty(destination).SetValue(pub, fieldValue, null);
                    }
                    else if (destType == "datetime")
                    {
                        DateTime date = DateTime.Now;
                        try
                        {
                            DateTime.TryParse(fieldValue, out date);
                            typeof(IRISPublication).GetProperty(destination).SetValue(pub, date, null);
                        }
                        catch (Exception ex)
                        {
                            //TODO Log date errors
#warning Empty catch statement
                        }
                    }
                }
                else 
                {
                    //--set multi valued types manually (authors and type)
                    switch (fieldCode)
                    {
                        case "TY":
                            pub.PublicationType = (RISType)Enum.Parse(typeof(RISType), fieldValue);
                            break;
                        case "AU":
                            //--there may be multiple authors...
                            Person author = ParsePerson(fieldValue);
                            if (author != null)
                            {
                                pub.Authors.Add(author);
                            }
                            break;
                        case "KW":
                            pub.Keywords.Add(fieldValue);
                            break;
                    }
                    
                }
            }
            else
            {
                //TODO mapping node null, could not map so log or error
#warning Empty else block
            }
        }

        /// <summary>
        /// Parses a person type field to get a Person object
        /// </summary>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        protected Person ParsePerson(string fieldValue)
        {
            string[] tokens = fieldValue.Split(',');
            Person p = null;
            if (tokens.Count() > 0)
            {
                if (tokens.Count() == 1)
                {
                    p = new Person
                    {
                        FirstName = tokens[0]
                    };
                }
                else
                {
                    p = new Person
                    {
                        FirstName = tokens[0],
                        LastName = tokens[1]
                    };
                }
            }
         
            return p;
        }


    }
}
