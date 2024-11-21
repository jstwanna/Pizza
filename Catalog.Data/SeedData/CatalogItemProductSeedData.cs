using Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.SeedData
{
    internal class CatalogItemProductSeedData
    {
        public static List<CatalogItemProduct> GetCatalogItemProducts()
        {
            return new List<CatalogItemProduct>()
            {
                new CatalogItemProduct
                {
                    Id = 1,
                    CatalogItemId = 1,
                    ProductId = 1,
                },
                new CatalogItemProduct
                {
                    Id = 2,
                    CatalogItemId = 1,
                    ProductId = 2,
                },
                new CatalogItemProduct
                {
                    Id = 3,
                    CatalogItemId = 1,
                    ProductId = 3,
                },
                new CatalogItemProduct
                {
                    Id = 4,
                    CatalogItemId = 1,
                    ProductId = 4,
                },
                new CatalogItemProduct
                {
                    Id = 5,
                    CatalogItemId = 1,
                    ProductId = 5,
                },
                new CatalogItemProduct
                {
                    Id = 6,
                    CatalogItemId = 6,
                    ProductId = 15,
                },
                new CatalogItemProduct
                {
                    Id = 7,
                    CatalogItemId = 6,
                    ProductId = 16,
                },
                new CatalogItemProduct
                {
                    Id = 8,
                    CatalogItemId = 6,
                    ProductId = 17,
                },
                new CatalogItemProduct
                {
                    Id = 9,
                    CatalogItemId = 6,
                    ProductId = 18,
                },
                new CatalogItemProduct
                {
                    Id = 10,
                    CatalogItemId = 6,
                    ProductId = 14,
                },
                new CatalogItemProduct
                {
                    Id = 11,
                    CatalogItemId = 2,
                    ProductId = 6,
                },
                new CatalogItemProduct
                {
                    Id = 12,
                    CatalogItemId = 3,
                    ProductId = 7,
                },
                new CatalogItemProduct
                {
                    Id = 13,
                    CatalogItemId = 4,
                    ProductId = 8,
                },
                new CatalogItemProduct
                {
                    Id = 14,
                    CatalogItemId = 5,
                    ProductId = 9,
                },
                new CatalogItemProduct
                {
                    Id = 15,
                    CatalogItemId = 5,
                    ProductId = 10,
                },
                new CatalogItemProduct
                {
                    Id = 16,
                    CatalogItemId = 5,
                    ProductId = 11,
                },
                new CatalogItemProduct
                {
                    Id = 17,
                    CatalogItemId = 5,
                    ProductId = 12,
                },
                new CatalogItemProduct
                {
                    Id = 18,
                    CatalogItemId = 5,
                    ProductId = 13,
                },
                new CatalogItemProduct
                {
                    Id = 19,
                    CatalogItemId = 7,
                    ProductId = 19,
                },
                new CatalogItemProduct
                {
                    Id = 20,
                    CatalogItemId = 8,
                    ProductId = 20,
                },
                new CatalogItemProduct
                {
                    Id = 21,
                    CatalogItemId = 9,
                    ProductId = 21,
                },
                //new CatalogItemProduct
                //{
                //    Id = 22,
                //    CatalogItemId = 10,
                //    ProductId = 3,
                //},
                //new CatalogItemProduct
                //{
                //    Id = 23,
                //    CatalogItemId = 10,
                //    ProductId = 11,
                //},
                //new CatalogItemProduct
                //{
                //    Id = 24,
                //    CatalogItemId = 10,
                //    ProductId = 16,
                //}
            };
        }
    }
}
