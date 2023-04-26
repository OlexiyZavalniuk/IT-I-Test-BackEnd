using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;

namespace BL
{
	public interface IBooksService
	{
		public Task<IEnumerable<Book>> GetAllBooksAsync();

		public Task<Book> GetBookByIdAsync(int id);

		public Task DeleteBookByIdAsync(int id);

		public Task<Book> AddBookAsync(Book0 book);

		public Task<Book> EditBookAsync(Book book);
	}
}
