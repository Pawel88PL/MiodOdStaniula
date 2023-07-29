using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Models;
using System.Reflection.Emit;

namespace MiodOdStaniula
{
    public class DbStoreContext : IdentityDbContext<UserModel>
    {
        public DbStoreContext(DbContextOptions<DbStoreContext> options) : base(options) { }

        

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<Client>? Clients { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
