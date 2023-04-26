using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DB;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BL
{
	public class BooksService : IBooksService
	{
		private readonly ApplicationContext _db;

		public BooksService(ApplicationContext appContext)
		{
			_db = appContext;
		}

		public async Task<IEnumerable<Book>> GetAllBooksAsync()
		{
			return await _db.Books.ToArrayAsync();
		}

		public async Task<Book> GetBookByIdAsync(int id)
		{
			return await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task DeleteBookByIdAsync(int id)
		{
			var book = new Book { Id = id };
			_db.Books.Attach(book);
			_db.Books.Remove(book);
			await _db.SaveChangesAsync();
		}

		public async Task<Book> AddBookAsync(Book0 book)
		{
			var bookToAdd = new Book
			{
				Title = book.Title,
				Description = book.Description,
				Pages = book.Pages,
				Date = book.Date
			};
			await _db.Books.AddAsync(bookToAdd);
			await _db.SaveChangesAsync();

			return await _db.Books.LastAsync();
		}

		public async Task<Book> EditBookAsync(Book book)
		{
			var bookTOEdit = await _db.Books.FirstOrDefaultAsync(x => x.Id == book.Id);

			if (bookTOEdit == null)
			{
				return null;
			}

			bookTOEdit.Title = book.Title;
			bookTOEdit.Description = book.Description;
			bookTOEdit.Pages = book.Pages;
			bookTOEdit.Date = book.Date;

			await _db.SaveChangesAsync();

			return book;
		}
	}
}
