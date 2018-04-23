using Microsoft.EntityFrameworkCore;
using TinyShoppingCart.Server.DataAccess.Mappings;
using TinyShoppingCart.Server.Domain.Entities;

namespace TinyShoppingCart.Server.DataAccess
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