using Microsoft.EntityFrameworkCore;
using webapi.Entities;

namespace webapi.DbContexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) { }
    }
}
