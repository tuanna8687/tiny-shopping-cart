using Microsoft.EntityFrameworkCore;
using TinyShoppingCart.Infrastructure.Persistence.Mappings;
using TinyShoppingCart.Domain.Entities;

namespace TinyShoppingCart.Infrastructure.Persistence
{
    public class TinyShoppingCartDbContext : DbContext
    {
        public TinyShoppingCartDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration<ProductCategory>(new ProductCategoryConfiguration());
        }

        DbSet<ProductCategory> ProductCategories {get;set;}
    }
}