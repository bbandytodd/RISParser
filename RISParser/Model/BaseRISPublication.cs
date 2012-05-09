namespace RISParser.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class BaseRISPublication : IRISPublication
    {
        private RISType _risType;
        private string _title;
        private List<Person> _authors;

        public BaseRISPublication()
        {
            _authors = new List<Person>();
        }

        public RISType PublicationType
        {
            get { return this._risType; }
            set { this._risType = value; }
        }

        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        public List<Person> Authors
        {
            get { return this._authors; }
            set { this._authors = value; }
        }
    }
}
