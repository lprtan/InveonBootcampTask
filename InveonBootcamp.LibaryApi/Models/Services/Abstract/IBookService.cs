using InveonBootcamp.LibaryApi.Models.Entities;

namespace InveonBootcamp.LibaryApi.Models.Services.Abstract
{
    public interface IBookService
    {
        void AddBook(Book book);
        void DeleteBook(Book book);
        void UpdateBook(Book book);
        List<Book> GetAllList();
        Book GetByID(int id);
        Task<IQueryable<Book>> GetQueryableBookPagination(int pageNumber, int pageSize);
    }
}
