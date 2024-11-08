using Catalog.Data.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Database.SeedData
{
    internal class ViewTypeSeedData
    {
        public static List<ViewType> GetViewTypeSeedDatas ()
        {
            return new()
            {
                new ViewType
                {
                    Id = 1,
                    Name = "Пицца"
                },
                new ViewType
                {
                    Id = 2,
                    Name = "Комбо"
                },
                new ViewType
                {
                    Id = 3,
                    Name = "Другое"
                }
            };
        }
    }
}
