using Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.SeedData
{
    internal class ProductSeedData
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Image = "CarbonaraBig.png",
                    Price = 999,
                    ProductTypeId = 1,
                    Name = "Карбонара"
                },
                new Product
                {
                    Id = 2,
                    Image = "CarbonaraBigThin.png",
                    Price = 999,
                    ProductTypeId = 1,
                    Name = "Карбонара"
                },
                new Product
                {
                    Id = 3,
                    Image = "CarbonaraMedium.png",
                    Price = 879,
                    ProductTypeId = 1,
                    Name = "Карбонара"
                },
                new Product
                {
                    Id = 4,
                    Image = "CarbonaraMediumThin.png",
                    Price = 879,
                    ProductTypeId = 1,
                    Name = "Карбонара"
                },
                new Product
                {
                    Id = 5,
                    Image = "CarbonaraSmall.png",
                    Price = 569,
                    ProductTypeId = 1,
                    Name = "Карборнара"
                },
                new Product
                {
                    Id = 6,
                    Image = "denvich1.png",
                    Price = 259,
                    ProductTypeId = 2,
                    Name = "Дэнвич ветчина и сыр"
                },
                new Product
                {
                    Id = 7,
                    Image = "denvich2.png",
                    Price = 259,
                    ProductTypeId = 2,
                    Name = "Дэнвич чоризо барбекю"
                },
                new Product
                {
                    Id = 8,
                    Image = "denvich3.png",
                    Price = 349,
                    ProductTypeId = 2,
                    Name = "Паста Карбонара"
                },
                new Product
                {
                    Id = 9,
                    Image = "MeatBig.png",
                    Price = 919,
                    ProductTypeId = 1,
                    Name = "Мясная"
                },
                new Product
                {
                    Id = 10,
                    Image = "MeatBigThin.png",
                    Price = 919,
                    ProductTypeId = 1,
                    Name = "Мясная"
                },
                new Product
                {
                    Id = 11,
                    Image = "MeatMedium.png",
                    Price = 779,
                    ProductTypeId = 1,
                    Name = "Мясная"
                },
                new Product
                {
                    Id = 12,
                    Image = "MeatMediumThin.png",
                    Price = 779,
                    ProductTypeId = 1,
                    Name = "Мясная"
                },
                new Product
                {
                    Id = 13,
                    Image = "MeatSmall.png",
                    Price = 519,
                    ProductTypeId = 1,
                    Name = "Мясная"
                },
                new Product
                {
                    Id = 14,
                    Image = "MixBig.png",
                    Price = 919,
                    ProductTypeId = 1,
                    Name = "Додо микс"
                },
                new Product
                {
                    Id = 15,
                    Image = "MixBigThin.png",
                    Price = 919,
                    ProductTypeId = 1,
                    Name = "Додо микс"
                },
                new Product
                {
                    Id = 16,
                    Image = "MixMedium.png",
                    Price = 779,
                    ProductTypeId = 1,
                    Name = "Додо микс"
                },
                new Product
                {
                    Id = 17,
                    Image = "MixMediumThin.png",
                    Price = 779,
                    ProductTypeId = 1,
                    Name = "Додо микс"
                },
                new Product
                {
                    Id = 18,
                    Image = "MixSmall.png",
                    Price = 519,
                    ProductTypeId = 1,
                    Name = "Додо микс"
                },
                new Product
                {
                    Id = 19,
                    Image = "omelette1.png",
                    Price = 185,
                    ProductTypeId = 2,
                    Name = "Омлет с беконом"
                },
                new Product
                {
                    Id = 20,
                    Image = "omelette2.png",
                    Price = 185,
                    ProductTypeId = 2,
                    Name = "Омлет с ветчиной и грибами"
                },
                new Product
                {
                    Id = 21,
                    Image = "omelette3.png",
                    Price = 185,
                    ProductTypeId = 2,
                    Name = "Омлет с пепперони"
                },
            };
        }
    }
}
