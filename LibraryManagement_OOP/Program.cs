using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565");
            Book book2 = new Book("1984", "George Orwell", "9780451524935");

            library.AddBook(book1);
            library.AddBook(book2);
            //library.DisplayBooks();

            library.BorrowBook("9780451524935", 1); //hiramin ni leo and 1984
            library.BorrowBook("1234567890\n", 1); //walang ganyan na libro
            library.BorrowBook("9780451524935", 2); //nahiram na to a
            library.BorrowBook("9780743273565", 1); //pwede ka lang manghiram ng isang libro

            //library.RemoveBook("9780451524935");
            //library.DisplayBooks();
        }
    }
}
