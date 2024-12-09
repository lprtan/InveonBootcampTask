using InveonBootcamp.LibaryApi.Models.Entities;
using InveonBootcamp.LibaryApi.Models.Repositories.Abstract;
using InveonBootcamp.LibaryApi.Models.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InveonBootcamp.LibaryApi.Models.Repositories.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
    }
}
