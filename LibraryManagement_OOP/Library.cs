using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_OOP
{
    /// <summary>
    /// Represents a library that manages a collection of books and borrowers.
    /// </summary>
    /// <remarks>The library allows adding and removing books, borrowing and returning books, and displaying
    /// the list of books. Each borrower can borrow only one book at a time.</remarks>
    class Library
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
        /// <summary>
        /// Adds a book to the collection.
        /// </summary>
        /// <param name="book">The book to add to the collection. Cannot be null.</param>
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        /// <summary>
        /// Removes a book from the collection based on its ISBN.
        /// </summary>
        /// <remarks>If no book with the specified ISBN exists in the collection, no action is
        /// taken.</remarks>
        /// <param name="isbn">The ISBN of the book to be removed. Cannot be null or empty.</param>
        public void RemoveBook(string isbn)
        {
            if (!books.Any(b => b._ISBN == isbn))
            {
                Console.WriteLine("walang ganyan na libro.");
                return;
            }
            books.RemoveAll(b => b._ISBN == isbn);
        }
        /// <summary>
        /// Allows a borrower to borrow a book from the library using the book's ISBN and the borrower's ID.
        /// </summary>
        /// <remarks>The method checks if the book is available and if the borrower has not already
        /// borrowed a book.  If the book is not available or the borrower has already borrowed a book, the operation
        /// will not proceed.</remarks>
        /// <param name="isbn">The ISBN of the book to be borrowed. Must correspond to an available book in the library.</param>
        /// <param name="id">The ID of the borrower attempting to borrow the book. Must correspond to a registered borrower.</param>
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
        /// <summary>
        /// Marks a book as returned and updates the borrower's status.
        /// </summary>
        /// <remarks>This method updates the availability status of the specified book and the borrowing
        /// status of the borrower. If the book or borrower does not exist, a message is displayed and the operation is
        /// aborted.</remarks>
        /// <param name="isbn">The ISBN of the book to be returned. Must correspond to an existing book in the collection.</param>
        /// <param name="id">The unique identifier of the borrower returning the book. Must correspond to an existing borrower.</param>
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
        /// <summary>
        /// Displays the details of each book in the collection to the console.
        /// </summary>
        /// <remarks>This method iterates over the collection of books and prints the title, ISBN, author,
        /// and availability status of each book.</remarks>
        public void DisplayBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book._Title} - ISBN: {book._ISBN} - Author: {book._Author} - Available: {(book._IsAvailable ? "Yes" : "No")}");
            }
        }
        /// <summary>
        /// Searches for books by title and displays their details.
        /// </summary>
        /// <remarks>If no books with the specified title are found, a message indicating that no such
        /// book exists is displayed. Otherwise, the details of each matching book, including title, ISBN, author, and
        /// availability, are printed to the console.</remarks>
        /// <param name="title">The title of the book to search for. The search is case-insensitive.</param>
        public void SearchBooks(string title)
        {
            var books = this.books.FindAll(b => b._Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (books == null)
            {
                Console.WriteLine("Walang ganyan na libro.");
            }
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book._Title} - ISBN: {book._ISBN} - Author: {book._Author} - Available: {(book._IsAvailable ? "Yes" : "No")}");
            }
        }

    }
}
