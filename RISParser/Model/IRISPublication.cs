namespace RISParser.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a RIS publication (e.g. a book, journal article etc)
    /// </summary>
    public interface IRISPublication
    {
        RISType PublicationType { get; set;}
        string Title { get; set; }
        string Abstract { get; set; }
        string AuthorAddress { get; set; }
        string AccessionNumber { get; set; }
        string Custom1 { get; set; }
        string Custom2 { get; set; }
        string Custom3 { get; set; }
        string Custom4 { get; set; }
        string Custom5 { get; set; }
        string Custom6 { get; set; }
        string Custom7 { get; set; }
        string Custom8 { get; set; }
        string Caption { get; set; }
        string CallNumber { get; set; }
        string PlacePublished { get; set; }
        DateTime Date { get; set; }
        string NameOfDatabase { get; set; }
        string DOI { get; set; }
        string DatabaseProvider { get; set; }
        string Edition { get; set; }
        string AlternateTitle { get; set; }
        List<string> Keywords { get; set; }
        string Figure { get; set; }
        string Language { get; set; }
        string Label { get; set; }
        string Number { get; set; }
        string TypeOfWork { get; set; }
        string Notes { get; set; }
        string NumberOfVolumes { get; set; }
        string OriginalPublication { get; set; }
        string Publisher { get; set; }
        string Year { get; set; }
        string Url { get; set; }
        string SecondaryAuthor { get; set; }
        string TertiaryAuthor { get; set; }
        string SubsidiaryAuthor { get; set; }
        List<Person> Authors { get; set;}

        string ReviewedItem { get; set; }
        string ResearchNotes { get; set; }
        string ReprintEdition { get; set; }
        string Section { get; set; }
        string ISBNISSN { get; set; }
        string Pages { get; set; }
        string ShortTitle { get; set; }

    }
}
