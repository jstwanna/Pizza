using Catalog.Data.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Database.SeedData
{
    internal class ProductTypeSeedData
    {
        public static List<ProductType> GetProductTypes ()
        {
            return new List<ProductType>()
            {
                new ProductType
                {
                    Id = 1,
                    Name = "Пицца"
                },
                new ProductType
                {
                    Id = 2,
                    Name = "Прочая еда"
                },
                new ProductType
                {
                    Id = 3,
                    Name = "Напиток"
                },
                new ProductType
                {
                    Id = 4,
                    Name = "Прочее"
                },
            };
        }
    }
}
