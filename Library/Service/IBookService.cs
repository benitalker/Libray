using Library.ViewModel;

namespace Library.Service
{
	public interface IBookService
	{
		void CreateBook(BookVM bookVM);
		long FindShelfById(long id);
		long FindSetById(long id);
		void DeleteBook(long id);
	}
}
