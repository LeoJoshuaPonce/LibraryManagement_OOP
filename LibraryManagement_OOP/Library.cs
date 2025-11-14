using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_OOP
{
    internal class Library
    {
        List<Book> books;
        List<Borrower> borrowers;

        public Library()
        {
            DateTime currentTime = DateTime.Now;

            int currentYear = currentTime.Year;

            books = new List<Book>();
            borrowers = new List<Borrower>();

            foreach (var id in Enumerable.Range(1, 5))
            {
                borrowers.Add(new Borrower(id, $"{currentYear % 100}-{id.ToString("D4")}c"));
            }
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void RemoveBook(string isbn)
        {
            if (!books.Any(b => b._ISBN == isbn))
            {
                Console.WriteLine("walang ganyan na libro.");
                return;
            }
            books.RemoveAll(b => b._ISBN == isbn);
        }
        public void BorrowBook(string isbn, int id)
        {
            if (!books.Any(b => b._ISBN == isbn))
            {
                Console.WriteLine("walang ganyan na libro.");
                return;
            }
            if (!borrowers.Any(b => b._Id == id))
            {
                Console.WriteLine("walang ganyan na tao.");
                return;
            }

            var borrower = borrowers.First(b => b._Id == id);

            if (borrower._HasBorrowed)
            {
                Console.WriteLine("Pwede ka lang manghiram ng isang libro.");
                return;
            }

            else
            {
                borrower._HasBorrowed = true;
            }

            var book = books.First(b => b._ISBN == isbn);

            if (!book._IsAvailable)
            {
                Console.WriteLine("Hindi available ang libro");
            }

            else
            {
                book._IsAvailable = false;
                Console.WriteLine($"Hiniram mo ang {book._Title} by {book._Author} tang ina mo {borrower._Name}");
            }

        }
        public void ReturnBook(string isbn, int id)
        {
            var borrower = borrowers.First(b => b._Id == id);
            var book = books.First(b => b._ISBN == isbn);

            if (!books.Any(b => b._ISBN == isbn))
            {
                Console.WriteLine("walang ganyan na libro bro");
                return;
            }

            if (!borrowers.Any(b => b._Id == id))
            {
                Console.WriteLine("walang ganyan na tao teh");
                return;
            }

            borrower._HasBorrowed = false;
            book._IsAvailable = true;
            Console.WriteLine($"ibinalik mo ang {book._Title} by {book._Author} salamat {borrower._Name}");
        }
        public void DisplayBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"_Title: {book._Title}, isbn: {book._ISBN}, _Author: {book._Author}");
            }
        }
    }
}
