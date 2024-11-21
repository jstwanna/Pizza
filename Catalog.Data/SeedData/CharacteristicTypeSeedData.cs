using Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.SeedData
{
    internal class CharacteristicTypeSeedData
    {
        public static List<СharacteristicType> GetСharacteristicTypes()
        {
            return new List<СharacteristicType>()
            {
                new СharacteristicType
                {
                    Id = 1,
                    Name = "Вес",
                    Description = ""
                },
                new СharacteristicType
                {
                    Id = 2,
                    Name = "Размер",
                    Description = ""
                },
                new СharacteristicType
                {
                    Id = 3,
                    Name = "Тип теста",
                    Description = ""
                },
                new СharacteristicType
                {
                    Id = 4,
                    Name = "Количество",
                    Description = ""
                },
            };
        }
    }
}
