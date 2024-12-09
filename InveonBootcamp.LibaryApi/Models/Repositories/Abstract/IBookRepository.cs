using InveonBootcamp.LibaryApi.Models.Entities;
using InveonBootcamp.LibaryApi.Models.Repositories.Concrete;

namespace InveonBootcamp.LibaryApi.Models.Repositories.Abstract
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}
