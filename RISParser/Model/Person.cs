
namespace RISParser.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A simple Person object
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The person's first name (or initials if the RIS file contains an entry such as 'Jones,A.B'
        /// </summary>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// The person's last name
        /// </summary>
        public string LastName
        {
            get;
            set;
        }
    }
}
