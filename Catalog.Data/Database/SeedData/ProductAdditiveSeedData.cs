using Catalog.Data.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Database.SeedData
{
    internal class ProductAdditiveSeedData
    {
        public static List<ProductAdditive> GetProductAdditiveSeedDatas ()
        {
            var pizzas = ProductSeedData
                    .GetProducts()
                    .Where(w => w.ProductTypeId == 1);

            var additives = AdditivesSeedData
                    .GetAdditives();

            var result = new List<ProductAdditive>();

            var rnd = new Random();
            var id = 1;

            foreach (var p in pizzas)
            {
                var additivesToAdd = additives
                    .Take(rnd.Next(additives.Count));

                foreach (var additive in additivesToAdd)
                {
                    result.Add(new()
                    {
                        Id = id++,
                        ProductId = p.Id,
                        AdditiveId = additive.Id
                    });
                }
            }

            return result;
        }
    }
}
