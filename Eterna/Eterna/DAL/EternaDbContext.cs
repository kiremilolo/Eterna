using Eterna.Models;
using Microsoft.EntityFrameworkCore;

namespace Eterna.DAL
{
    public class EternaDbContext:DbContext
    {
        public EternaDbContext(DbContextOptions<EternaDbContext> opt):base(opt)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ProductClient> ProductClient { get; set; } 
        public DbSet<Category> Category { get; set; }   



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductClient>(x => x.HasKey(bt => new { bt.ProductId, bt.ClientId }));
        }
    }
}
