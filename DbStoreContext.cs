using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Models;

namespace MiodOdStaniula
{
    public class DbStoreContext : DbContext
    {
        public DbStoreContext(DbContextOptions<DbStoreContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Client> Clients { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
