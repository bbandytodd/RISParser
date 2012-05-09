using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using RISParser;

namespace RISParserStub
{
    /// <summary>
    /// This is a stub command line exe for demonstrating the library
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            RISParser.RISParser parser = new RISParser.RISParser();
            parser.ParseRISDocument(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\samples\ris.ris");
        }
    }
}
