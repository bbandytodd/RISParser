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
        RISType PublicationType {
            get;
            set;
        }

        string Title
        {
            get;
            set;
        }

        List<Person> Authors
        {
            get;
            set;
        }
    }
}
