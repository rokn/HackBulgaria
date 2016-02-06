using System;
using System.Linq;

namespace LibraryManagement
{
	public class LoanAccess : IDisposable
	{
		private readonly HackLibraryDataContext _libraryContext;

		public LoanAccess()
		{
			_libraryContext = new HackLibraryDataContext();
		}

		public bool LoanBook(int id, long isbn)
		{
			var hardCopy = _libraryContext.HardCopies.FirstOrDefault(copy => copy.BookISBN == isbn && copy.UserLeantTo == null);

			if (hardCopy != null)
			{
				hardCopy.UserLeantTo = id;
				hardCopy.LeantDate = DateTime.Now;
				hardCopy.ExpectedReturnDate = new DateTime(hardCopy.LeantDate.Value.Year, hardCopy.LeantDate.Value.Month, hardCopy.LeantDate.Value.Day);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void ReturnBook(HardCopy copy)
		{

			var history = new BookLeaningHistory
			{
				HardCopyId = copy.Id,
				UserLeantTo = copy.UserLeantTo.Value,
				LeantDate = copy.LeantDate.Value,
				ReturnedDate = DateTime.Now
			};

			_libraryContext.BookLeaningHistories.InsertOnSubmit(history);
			_libraryContext.SubmitChanges();
		}

		public void Dispose()
		{
			_libraryContext.SubmitChanges();
			_libraryContext.Dispose();
		}
	}
}
