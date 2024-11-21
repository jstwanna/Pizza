using Catalog.Data;
using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Domain.Services
{
    internal class CatalogService : ICatalogService
    {
        private readonly CatalogDbContext dbContext;

        public CatalogService(CatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<string[]> GetCategoriesList(CancellationToken cancellationToken)
        {
            return dbContext.CatalogCategories
                .Select(s => s.Name)
                .ToArrayAsync(cancellationToken);
        }

        public Task<CatalogItemListView[]> GetCatalogItems (CancellationToken cancellationToken)
        {
            return dbContext.CatalogItems
                .Include(i => i.CatalogCategory)
                .Include(i => i.Products)
                .ThenInclude(p => p.Characteristics)
                .ThenInclude(pa => pa.CharacteristicType)
                .Include(i => i.Products)
                .ThenInclude(p => p.Additives)
                .Include(i => i.Products)
                .ThenInclude(p => p.ProductType)
                .Include(i => i.ViewType)
                .Select(s => new CatalogItemListView
                {
                    Category = s.CatalogCategory.Name,
                    Description = s.Description,
                    Image = s.Image,
                    Name = s.Name,
                    ViewType = s.ViewType.Name,
                    Products = s.Products.Select(s => new ProductListView
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Image = s.Image,
                        Price = s.Price,
                        ProductType = s.ProductType.Name,
                        Characteristics = s.Characteristics.Select(s => new CharacteristicsListView
                        {
                            Name = s.CharacteristicType.Name,
                            Value = s.Value
                        }).ToArray(),
                        Additives = s.Additives.Select(s => new AdditiveListView
                        {
                            Id = s.Id,
                            Image = s.Image,
                            Name = s.Name,
                            Price = s.Price,
                        }).ToArray()
                    }).ToArray()
                }).ToArrayAsync(cancellationToken);
        }
    }
}
