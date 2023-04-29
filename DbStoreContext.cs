using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Models;

namespace MiodOdStaniula
{
    public class DbStoreContext : IdentityDbContext<UserModel>
    {
        public DbStoreContext(DbContextOptions<DbStoreContext> options) : base(options) { }

        

        public DbSet<Product> Products { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
