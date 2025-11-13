using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_OOP
{
    public class Book
    {
        public string _Title { get; set; }
        public string _Author { get; set; }
        public string _ISBN { get; set; }
        public bool _IsAvailable { get; set; } = true;
        public Book(string title, string author, string isbn)
        {
            _Title = title;
            _Author = author;
            _ISBN = isbn;
        }
    }
}
