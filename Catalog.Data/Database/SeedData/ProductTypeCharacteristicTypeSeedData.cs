using Catalog.Data.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Database.SeedData
{
    internal class ProductTypeCharacteristicTypeSeedData
    {
        public static List<ProductTypeСharacteristicTypes> GetProductTypeСharacteristicTypes ()
        {
            return new List<ProductTypeСharacteristicTypes>()
            {
                new ProductTypeСharacteristicTypes
                {
                    Id = 1,
                    ProductTypeId = 1,
                    СharacteristicTypeId = 1
                },
                new ProductTypeСharacteristicTypes
                {
                    Id = 2,
                    ProductTypeId = 1,
                    СharacteristicTypeId = 2
                },
                new ProductTypeСharacteristicTypes
                {
                    Id = 3,
                    ProductTypeId = 1,
                    СharacteristicTypeId = 3
                },
                new ProductTypeСharacteristicTypes
                {
                    Id = 4,
                    ProductTypeId = 2,
                    СharacteristicTypeId = 1
                },
                new ProductTypeСharacteristicTypes
                {
                    Id = 5,
                    ProductTypeId = 2,
                    СharacteristicTypeId = 4
                },
                new ProductTypeСharacteristicTypes
                {
                    Id = 6,
                    ProductTypeId = 3,
                    СharacteristicTypeId = 1
                },
                new ProductTypeСharacteristicTypes
                {
                    Id = 7,
                    ProductTypeId = 3,
                    СharacteristicTypeId = 2
                },
                new ProductTypeСharacteristicTypes
                {
                    Id = 8,
                    ProductTypeId = 4,
                    СharacteristicTypeId = 4
                },
            };
        }
    }
}
