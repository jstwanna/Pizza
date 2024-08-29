using Catalog.Data.Database;
using Catalog.Data.Database.Models;
using Microsoft.EntityFrameworkCore;
using Pizza.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Services
{
    internal class CatalogService : ICatalogService
    {
        private readonly CatalogDbContext dbContext;

        public CatalogService(CatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<PizzaListView> GetAllPizzas ()
        {
            var pizzas = dbContext.Pizzas
                .Include(i => i.PizzaType)
                .Include(i => i.DoughType)
                .Include(i => i.PizzaSize)
                .Include(i => i.Additives)
                .GroupBy(g => g.PizzaTypeId)
                .Select(s => new PizzaListView
                {
                    Id = s.Key,
                    Pizzas = s.Select(s => new PizzaView
                    {
                        Image = s.Image,
                        PizzaSize = s.PizzaSize.Name,
                        DoughType = s.DoughType.Name,
                        PizzaType = s.PizzaType.Name,
                        Price = s.Price,
                        Weight = s.Weight,
                        Additives = s.Additives.Select(x => new AdditiveView
                        {
                            Id = x.Id,
                            Image = x.Image,
                            Name = x.Name,
                            Price = x.Price,
                        })
                    })
                })
                .ToArray();

            return pizzas;
        }

        public IEnumerable<ProductListView> GetAllProducts ()
        {
            var products = dbContext.Products
                .Include(i => i.ProductType)
                .Select(s => new ProductListView
                {
                    Count = s.Count,
                    CountMeasurement = s.CountMeasurement,
                    Description = s.Description,
                    Id = s.Id,
                    Image = s.Image,
                    Name = s.Name,
                    ProductType = s.ProductType.Name,
                    Weight = s.Weight
                })
                .ToArray();

            return products;
        }
    }
}
