using Library.Service;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookService _bookService;
		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		public IActionResult Create(long id)
		{
			return View(new BookVM() { SetId = id });
		}

		[HttpPost]
		public IActionResult Create(BookVM bookVM)
		{
			_bookService.CreateBook(bookVM);
			return RedirectToAction("Index","Set", new { id = _bookService.FindShelfById(bookVM.SetId) });
		}

		public IActionResult Delete(long id) 
		{
			long setId = _bookService.FindSetById(id);
			long shelfId = _bookService.FindShelfById(setId);
			_bookService.DeleteBook(id);
			return RedirectToAction("Index","Set",new {id = shelfId});
		}
	}
}
