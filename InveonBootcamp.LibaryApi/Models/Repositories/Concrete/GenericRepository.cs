using InveonBootcamp.LibaryApi.Models.Repositories.Abstract;
using InveonBootcamp.LibaryApi.Models.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace InveonBootcamp.LibaryApi.Models.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        AppDbContext _dbContext = new AppDbContext();
        public void Delete(T t)
        {
            _dbContext.Remove(t);
            _dbContext.SaveChanges();
        }

        public T GetByID(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public List<T> GetListAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _dbContext.Add(t);
            _dbContext.SaveChanges();
        }

        public async Task<IQueryable<T>> GetQueryable(int pageNumber, int pageSize)
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public void Update(T t)
        {
            _dbContext.Update(t);
            _dbContext.SaveChanges();
        }
    }
}
