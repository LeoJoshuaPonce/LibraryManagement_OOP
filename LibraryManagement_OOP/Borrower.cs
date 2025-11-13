using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_OOP
{
    internal class Borrower
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
