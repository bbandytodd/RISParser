using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

using RISParser.Model;

namespace RISParser
{
    public class RISParser
    {

        /// <summary>
        /// Parses the RIS file at the specified path and returns a RISPublication object
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
                Console.WriteLine(field);
                //--each field is formatted FC - FV where FC is a field code and FV is the value
                string[] fieldArray = Regex.Split(field, " - ");
                if (fieldArray.Count() == 2)
                {
                    ParseField(fieldArray, pub);
                }
                else
                {
                    //TODO invalid or empty field, should probably log this
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

            //--now that we have the field code and its value, we need to parse the field code to understand what it is
            switch (fieldCode)
            {
                case "TY" :
                    pub.PublicationType = (RISType) Enum.Parse(typeof(RISType), fieldValue);
                    break;
                case "TI" :
                    pub.Title = fieldValue;
                    break;
                case "AU":
                    //--there may be multiple authors...
                    Person author = ParsePerson(fieldValue);
                    if (author != null)
                    {
                        pub.Authors.Add(author);
                    }
                    break;
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
