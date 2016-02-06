using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
	public class AuthorsAccess : IDisposable
	{
		private readonly HackLibraryDataContext _libraryContext;

		public AuthorsAccess()
		{
			_libraryContext = new HackLibraryDataContext();
		}

		public Author GetAuthorByName(string firstName, string lastName)
		{
			var authors = from author in _libraryContext.Authors
				where author.FirstName == firstName && author.LastName == lastName
				select author;
			return authors.FirstOrDefault();
		}

		public IEnumerable<Genre> GetWrittenGenres(Author author)
		{
			return from auth in _libraryContext.Authors
					where auth.FirstName == author.FirstName && auth.LastName == author.LastName
					from authorbook in auth.AuthorBooks
					from bookgenre in authorbook.Book.BookGenres
					select bookgenre.Genre;
		}

		public void Dispose()
		{
			_libraryContext.SubmitChanges();
			_libraryContext.Dispose();
		}
	}
}
