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
        private string _abstract;
        private string _authorAddress;
        private string _accessionNumber;
        private string _custom1;
        private string _custom2;
        private string _custom3;
        private string _custom4;
        private string _custom5;
        private string _custom6;
        private string _custom7;
        private string _custom8;
        private string _caption;
        private string _callNumber;
        private string _placePublished;
        private DateTime _date;
        private string _nameOfDatabase;
        private string _DOI;
        private string _databaseProvider;
        private string _edition;
        private string _alternateTitle;
        private List<string> _keywords;
        private string _figure;
        private string _language;
        private string _label;
        private string _number;
        private string _typeOfWork;
        private string _year;
        private string _notes;
        private string _publisher;
        private string _numberOfVolumes;
        private string _originalPublication;

        public string AccessionNumber
        {
            get { return _accessionNumber; }
            set { _accessionNumber = value; }
        }
       
        public string Custom1
        {
            get { return _custom1; }
            set { _custom1 = value; }
        }
        public string Custom2
        {
            get { return _custom2; }
            set { _custom2 = value; }
        }

        public string Custom3
        {
            get { return _custom3; }
            set { _custom3 = value; }
        }

        public string Custom4
        {
            get { return _custom4; }
            set { _custom4 = value; }
        }

        public string Custom5
        {
            get { return _custom5; }
            set { _custom5 = value; }
        }

        public string Custom6
        {
            get { return _custom6; }
            set { _custom6 = value; }
        }

        public string Custom7
        {
            get { return _custom7; }
            set { _custom7 = value; }
        }

        public string Custom8
        {
            get { return _custom8; }
            set { _custom8 = value; }
        }
        
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }
        
        public string CallNumber
        {
            get { return _callNumber; }
            set { _callNumber = value; }
        }
        
        public string PlacePublished
        {
            get { return _placePublished; }
            set { _placePublished = value; }
        }
        
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        
        public string NameOfDatabase
        {
            get { return _nameOfDatabase; }
            set { _nameOfDatabase = value; }
        }
        
        public string DOI
        {
            get { return _DOI; }
            set { _DOI = value; }
        }
        
        public string DatabaseProvider
        {
            get { return _databaseProvider; }
            set { _databaseProvider = value; }
        }
        
        public string Edition
        {
            get { return _edition; }
            set { _edition = value; }
        }
        
        public string AlternateTitle
        {
            get { return _alternateTitle; }
            set { _alternateTitle = value; }
        }
        
        public List<string> Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
        
        public string Figure
        {
            get { return _figure; }
            set { _figure = value; }
        }
        
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
        
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }
        
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
        
        public string TypeOfWork
        {
            get { return _typeOfWork; }
            set { _typeOfWork = value; }
        }
        
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
        
        public string NumberOfVolumes
        {
            get { return _numberOfVolumes; }
            set { _numberOfVolumes = value; }
        }
        
        public string OriginalPublication
        {
            get { return _originalPublication; }
            set { _originalPublication = value; }
        }
        
        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }
        
        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }

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

        public string Abstract
        {
            get { return this._abstract; }
            set { this._abstract = value; }
        }

        public string AuthorAddress
        {
            get { return _authorAddress; }
            set { _authorAddress = value; }
        }
    }
}
