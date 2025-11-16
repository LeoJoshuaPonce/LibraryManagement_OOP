using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_OOP
{
    /// <summary>
    /// Represents a borrower with an identifier, name, and borrowing status.
    /// </summary>
    /// <remarks>This class is used to track the borrowing status of an individual.  It includes properties
    /// for the borrower's ID, name, and whether they have borrowed an item.</remarks>
    class Borrower
    {
        public int _Id { get; set; }
        public string _Name { get; set; }
        public bool _HasBorrowed { get; set; } = false;
        public Borrower(int id, string name)
        {
            _Id = id;
            _Name = name;
        }
    }
}
