using Microsoft.EntityFrameworkCore;

namespace InveonBootcamp.LibaryApi.Models.Pagination
{
    public class PaginationHelper<T>
    {
        public static async Task<Pagination<T>> GetPagedResultAsync(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Pagination<T>
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                Items = items
            };
        }

    }
}
