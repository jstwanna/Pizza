using Catalog.Data.Models;
using Catalog.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Additive> Additives { get; set; }
        public DbSet<CatalogCategory> CatalogCategories { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogItemProduct> CatalogItemsProduct { get; set; }
        public DbSet<ViewType> ViewTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAdditive> ProductAdditives { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductTypeСharacteristicTypes> ProductTypeСharacteristics { get; set; }
        public DbSet<СharacteristicType> СharacteristicTypes { get; set; }
        public DbSet<Сharacteristic> Сharacteristics { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Additive>()
                .HasData(AdditivesSeedData.GetAdditives());

            modelBuilder
                .Entity<ProductType>()
                .HasData(ProductTypeSeedData.GetProductTypes());

            modelBuilder
                .Entity<Product>()
                .HasData(ProductSeedData.GetProducts());

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Additives)
                .WithMany(p => p.Products)
                .UsingEntity<ProductAdditive>()
                .HasData(ProductAdditiveSeedData.GetProductAdditiveSeedDatas());

            modelBuilder
                .Entity<СharacteristicType>()
                .HasData(CharacteristicTypeSeedData.GetСharacteristicTypes());

            modelBuilder
                .Entity<СharacteristicType>()
                .HasMany(p => p.ProductTypes)
                .WithMany(p => p.Сharacteristics)
                .UsingEntity<ProductTypeСharacteristicTypes>()
                .HasData(ProductTypeCharacteristicTypeSeedData.GetProductTypeСharacteristicTypes());

            modelBuilder
                .Entity<Сharacteristic>()
                .HasData(CharacteristicSeedData.Сharacteristics());

            modelBuilder
                .Entity<CatalogCategory>()
                .HasData(CatalogCategorySeedData.GetCatalogCategories());

            modelBuilder
                .Entity<ViewType>()
                .HasData(ViewTypeSeedData.GetViewTypeSeedDatas());

            modelBuilder
                .Entity<CatalogItem>()
                .HasData(CatalogItemSeedData.GetCatalogItems());

            modelBuilder
                .Entity<CatalogItem>()
                .HasMany(p => p.Products)
                .WithMany(p => p.CatalogItems)
                .UsingEntity<CatalogItemProduct>()
                .HasData(CatalogItemProductSeedData.GetCatalogItemProducts());
        }
    }
}
