using Microsoft.EntityFrameworkCore;
using NorthwindWebMvc.Basic.Models;

namespace NorthwindWebMvc.Basic.RepositoryContext
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDetail> CategoryDetails { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers{ get; set; }

        public DbSet<Cart> Carts{ get; set; }
    }
}
