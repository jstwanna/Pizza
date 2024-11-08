using Catalog.Data.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Database.SeedData
{
    internal class CatalogCategorySeedData
    {
        public static List<CatalogCategory> GetCatalogCategories ()
        {
            return new()
            {
                new CatalogCategory
                {
                    Id = 1,
                    Name = "Пицца"
                },
                new CatalogCategory
                {
                    Id = 2,
                    Name = "Комбо"
                },
                new CatalogCategory
                {
                    Id = 3,
                    Name = "Закуски"
                },
                new CatalogCategory
                {
                    Id = 4,
                    Name = "Завтрак"
                },
                new CatalogCategory
                {
                    Id = 5,
                    Name = "Коктейли"
                },
                new CatalogCategory
                {
                    Id = 6,
                    Name = "Кофе"
                },
                new CatalogCategory
                {
                    Id = 7,
                    Name = "Напитки"
                },
                new CatalogCategory
                {
                    Id = 8,
                    Name = "Десерты"
                },
                new CatalogCategory
                {
                    Id = 9,
                    Name = "Любят дети"
                },
                new CatalogCategory
                {
                    Id = 10,
                    Name = "Соусы"
                },
                new CatalogCategory
                {
                    Id = 11,
                    Name = "Другие заказы"
                }
            };
        }
    }
}
