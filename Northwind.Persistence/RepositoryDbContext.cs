using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities.Master;
using Northwind.Domain.Entities.Sales;
using Northwind.Persistence.Configuration;


namespace Northwind.Persistence
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());   
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDetail> CategoryDetails { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Cart> Carts { get; set; }
    }
}
