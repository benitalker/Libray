using Library.Data;
using Library.Models;
using Library.ViewModel;

namespace Library.Service
{
	public class BookService : IBookService
	{
		private readonly ApplicationDbContext _context;
		public BookService(ApplicationDbContext context)
		{
			_context = context;
		}

		public void CreateBook(BookVM bookVM)
		{
			var book = new BookModel()
			{
				Name = bookVM.Name,
				Genre = bookVM.Genre,
				Height = bookVM.Height,
				Width = bookVM.Width,
				SetId = bookVM.SetId,
				Set = _context.Sets.Where(set => set.Id == bookVM.SetId).FirstOrDefault()
			};
			_context.Books.Add(book);
			_context.SaveChanges();
		}

		public void DeleteBook(long id)
		{
			BookModel? toDelete = _context.Books.Find(id);
			if (toDelete != null)
			{
				_context.Books.Remove(toDelete);
				_context.SaveChanges();
			}
		}

		public long FindSetById(long id)
		=> _context.Books.Where(set => set.Id == id).FirstOrDefault()!.SetId;

		public long FindShelfById(long id)
		=> _context.Sets.Where(set => set.Id == id).FirstOrDefault()!.ShelfId;

	}
}
