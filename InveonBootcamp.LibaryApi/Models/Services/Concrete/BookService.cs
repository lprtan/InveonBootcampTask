using InveonBootcamp.LibaryApi.Models.Entities;
using InveonBootcamp.LibaryApi.Models.Repositories.Abstract;
using InveonBootcamp.LibaryApi.Models.Services.Abstract;

namespace InveonBootcamp.LibaryApi.Models.Services.Concrete
{
    public class BookService : IBookService
    {
        IBookRepository _book;

        public BookService(IBookRepository book)
        {
            _book = book;
        }
        public void AddBook(Book book)
        {
            _book.Insert(book);
        }

        public void DeleteBook(Book book)
        {
            _book.Delete(book);
        }

        public List<Book> GetAllList()
        {
            return _book.GetListAll();
        }

        public Book GetByID(int id)
        {
            return _book.GetByID(id);
        }

        public Task<IQueryable<Book>> GetQueryableBookPagination(int pageNumber, int pageSize)
        {
            return _book.GetQueryable(pageNumber, pageSize);
        }

        public void UpdateBook(Book book)
        {
            _book.Update(book);
        }
    }
}
