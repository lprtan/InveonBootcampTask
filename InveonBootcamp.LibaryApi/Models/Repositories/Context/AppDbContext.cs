using InveonBootcamp.LibaryApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InveonBootcamp.LibaryApi.Models.Repositories.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-J7SKD7G;database=LibraryDb; integrated security=true;TrustServerCertificate=True;MultipleActiveResultSets=True");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
