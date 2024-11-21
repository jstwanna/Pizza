using Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.SeedData
{
    internal class AdditivesSeedData
    {
        public static List<Additive> GetAdditives()
        {
            return new()
                {
                    new Additive
                    {
                        Id = 1,
                        Image = "Chedder.png",
                        Name = "Сыры чеддер и пармезан",
                        Price = 79
                    },
                    new Additive
                    {
                        Id = 2,
                        Image = "Mozzarella.png",
                        Name = "Сливочная моцарелла",
                        Price = 79
                    },
                    new Additive
                    {
                        Id = 3,
                        Image = "Jalapeno.png",
                        Name = "Острый перец халапеньо",
                        Price = 59
                    },
                    new Additive
                    {
                        Id = 4,
                        Image = "Cucumbers.png",
                        Name = "Маринованные огурчики",
                        Price = 59
                    },
                    new Additive
                    {
                        Id = 5,
                        Image = "Tomat.png",
                        Name = "Свежие томаты",
                        Price = 59
                    },
                };
        }
    }
}
