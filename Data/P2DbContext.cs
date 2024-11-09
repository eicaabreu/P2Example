using Microsoft.EntityFrameworkCore;

namespace P2Example.Data
{
    public class P2DbContext : DbContext
    {
        public P2DbContext(DbContextOptions<P2DbContext> options) : base(options) { }

        public DbSet<Products> products { get; set; }
    }
}
