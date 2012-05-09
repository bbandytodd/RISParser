using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RISParser;

namespace RISParserStub
{
    class Program
    {
        static void Main(string[] args)
        {

            RISParser.RISParser parser = new RISParser.RISParser();
            parser.ParseRISDocument(@"C:\temp\ris.ris");

        }
    }
}
