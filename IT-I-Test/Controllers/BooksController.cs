using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

using BL;
using Models;

namespace IT_I_Test.Controllers
{
	public class BooksController : ActionController<BooksController>
	{
		private readonly IBooksService _booksService;

		public BooksController(ILogger<BooksController> logger, IBooksService service) : base(logger)
		{
			_booksService = service;
		}

		[Route("/api/books")]
		[HttpGet]
		public async Task<IActionResult> GetAllBooks()
		{
			return await ExecuteActionAsync(() =>
			{
				return _booksService.GetAllBooksAsync();
			});
		}

		[Route("/api/book/{id:int}")]
		[HttpGet]
		public async Task<IActionResult> GetBook(int id)
		{
			return await ExecuteActionAsync(() =>
			{
				return _booksService.GetBookByIdAsync(id);
			});
		}

		[Route("/api/book/{id:int}")]
		[HttpDelete]
		public async Task<IActionResult> DeleteBook(int id)
		{
			return await ExecuteActionWithoutResultAsync(() =>
			{
				return _booksService.DeleteBookByIdAsync(id);
			});
		}

		[Route("/api/book")]
		[HttpPost]
		public async Task<IActionResult> AddNewBook([FromBody] Book0 book)
		{
			return await ExecuteActionAsync(() =>
			{
				return _booksService.AddBookAsync(book);
			});
		}

		[Route("/api/book")]
		[HttpPut]
		public async Task<IActionResult> EditBook([FromBody] Book book)
		{
			return await ExecuteActionAsync(() =>
			{
				return _booksService.EditBookAsync(book);
			});
		}
	}
}
