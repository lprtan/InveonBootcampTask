using InveonBootcamp.LibaryApi.Models.Entities;

namespace InveonBootcamp.LibaryApi.Models.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetListAll();
        T GetByID(int id);
        Task<IQueryable<T>> GetQueryable(int pageNumber, int pageSize);
    }
}
