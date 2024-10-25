// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    private string _title;
    private string _author;
    private string _isbn;
    private int _copiesAvailable;

    public Book(string title, string author, string isbn, int copiesAvailable)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        CopiesAvailable = copiesAvailable;
    }

    // Properties with validation
    public string Title
    {
        get { return _title; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Title cannot be empty.");
            _title = value;
        }
    }

    public string Author
    {
        get { return _author; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Author cannot be empty.");
            _author = value;
        }
    }

    public string ISBN
    {
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 13)
                throw new ArgumentException("ISBN must be a 13-character string.");
            _isbn = value;
        }
    }

    public int CopiesAvailable
    {
        get { return _copiesAvailable; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Copies available cannot be negative.");
            _copiesAvailable = value;
        }
    }

    // Methods
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {_title}, Author: {_author}, ISBN: {_isbn}, Available Copies: {_copiesAvailable}");
    }

    public void BorrowBook()
    {
        if (_copiesAvailable > 0)
        {
            _copiesAvailable--;
            Console.WriteLine($"Book '{_title}' borrowed successfully.");
        }
        else
        {
            Console.WriteLine("No copies available to borrow.");
        }
    }

    public void ReturnBook()
    {
        _copiesAvailable++;
        Console.WriteLine($"Book '{_title}' returned successfully.");
    }
}

public class Library
{
    private List<Book> _books;

    public Library()
    {
        _books = new List<Book>();
    }

    // Methods to add, remove, and display all books
    public void AddBook(Book book)
    {
        _books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library.");
    }

    public void RemoveBook(string isbn)
    {
        var book = _books.FirstOrDefault(b => b.ISBN == isbn);
        if (book != null)
        {
            _books.Remove(book);
            Console.WriteLine($"Book with ISBN {isbn} removed from the library.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public void DisplayAllBooks()
    {
        if (_books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
        }
        else
        {
            foreach (var book in _books)
            {
                book.DisplayInfo();
            }
        }
    }

    // Search functionality
    public void SearchBook(string title = null, string author = null, string isbn = null)
    {
        var foundBooks = _books.Where(b =>
            (title != null && b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)) ||
            (author != null && b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)) ||
            (isbn != null && b.ISBN == isbn)).ToList();

        if (foundBooks.Count > 0)
        {
            Console.WriteLine("Books found:");
            foreach (var book in foundBooks)
            {
                book.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("No books match the search criteria.");
        }
    }
}

class Program
{
    static void Main()
    {
        var library = new Library();
        while (true)
        {
            Console.WriteLine("\nLibrary Menu:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Display All Books");
            Console.WriteLine("4. Search Book");
            Console.WriteLine("5. Borrow Book");
            Console.WriteLine("6. Return Book");
            Console.WriteLine("7. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter ISBN (13 characters): ");
                    string isbn = Console.ReadLine();
                    Console.Write("Enter number of copies: ");
                    int copiesAvailable;
                    if (int.TryParse(Console.ReadLine(), out copiesAvailable))
                    {
                        try
                        {
                            var book = new Book(title, author, isbn, copiesAvailable);
                            library.AddBook(book);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for copies.");
                    }
                    break;
                case "2":
                    Console.Write("Enter ISBN of the book to remove: ");
                    isbn = Console.ReadLine();
                    library.RemoveBook(isbn);
                    break;
                case "3":
                    library.DisplayAllBooks();
                    break;
                case "4":
                    Console.Write("Enter title to search (leave blank if not searching by title): ");
                    title = Console.ReadLine();
                    Console.Write("Enter author to search (leave blank if not searching by author): ");
                    author = Console.ReadLine();
                    Console.Write("Enter ISBN to search (leave blank if not searching by ISBN): ");
                    isbn = Console.ReadLine();
                    library.SearchBook(title, author, isbn);
                    break;
                case "5":
                    Console.Write("Enter ISBN of the book to borrow: ");
                    isbn = Console.ReadLine();
                    var bookToBorrow = library._books.FirstOrDefault(b => b.ISBN == isbn);
                    if (bookToBorrow != null)
                    {
                        bookToBorrow.BorrowBook();
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    break;
                case "6":
                    Console.Write("Enter ISBN of the book to return: ");
                    isbn = Console.ReadLine();
                    var bookToReturn = library._books.FirstOrDefault(b => b.ISBN == isbn);
                    if (bookToReturn != null)
                    {
                        bookToReturn.ReturnBook();
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    break;
                case "7":
                    Console.WriteLine("Exiting the library system.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

