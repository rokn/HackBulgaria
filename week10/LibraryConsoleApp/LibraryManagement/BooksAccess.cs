using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LibraryManagement
{
    public class BooksAccess : IDisposable
    {
	    private readonly HackLibraryDataContext _libraryContext;

		public BooksAccess()
	    {
		    _libraryContext = new HackLibraryDataContext();
	    }

	    public bool InsertBook(Book newBook)
	    {
		    var status = true;

		    try
		    {
			    _libraryContext.Books.InsertOnSubmit(newBook);
			    _libraryContext.SubmitChanges();
		    }
		    catch (SqlException)
		    {
			    status = false;
		    }

			return status;
		}

	    public IEnumerable<Book> GetAllBooksSortedByTitle()
	    {
		    return from book in _libraryContext.Books
					orderby book.Title
					select book;
	    }

		public IEnumerable<Book> GetAllBooksSortedByAuthor()
		{
			return from book in _libraryContext.Books
				   orderby book.AuthorBooks[0].Author.FirstName
				   select book;
		}

		public IEnumerable<Book> GetAllBooksSortedByGenre()
		{
			return from book in _libraryContext.Books
				   orderby book.BookGenres[0].Genre.Name
				   select book;
		}

	    public IEnumerable<Book> GetByAuthor(string firstName, string lastName)
	    {
		    return from book in _libraryContext.Books
					join author in _libraryContext.Authors
				    on book.AuthorBooks equals author.AuthorBooks
					where author.FirstName == firstName && author.LastName == lastName
					select book;
	    }

		public Book GetInfo(long isbn)
		{
			var books = from book in _libraryContext.Books
						where book.ISBN == isbn
						select book;

			return books.FirstOrDefault();
		}

		public Book GetInfo(string title)
		{
			var books = from book in _libraryContext.Books
						where book.Title.Contains(title)
						select book;

			return books.FirstOrDefault();
		}

		public void Dispose()
	    {
			_libraryContext.SubmitChanges();
		    _libraryContext.Dispose();
	    }
    }
}
