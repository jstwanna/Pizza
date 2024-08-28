using Catalog.Data.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data.Database
{
    public class CatalogDbContext : DbContext
    {
        //public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaSize> PizzaSizes { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<DoughType> DoughTypes { get; set; }

        public CatalogDbContext (DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
