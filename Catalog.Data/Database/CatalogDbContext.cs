using Catalog.Data.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data.Database
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<PizzaSize> PizzaSizes { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<DoughType> DoughTypes { get; set; }
        public DbSet<Additive> Additives { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<SimpleProduct> Products { get; set; }

        public CatalogDbContext (DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PizzaSize>()
                .HasData(
                new PizzaSize
                {
                    Id = 1,
                    Name = "Маленькая"
                },
                new PizzaSize
                {
                    Id = 2,
                    Name = "Средняя"
                },
                new PizzaSize
                {
                    Id = 3,
                    Name = "Большая"
                });

            modelBuilder
                .Entity<DoughType>()
                .HasData(
                new DoughType
                {
                    Id = 1,
                    Name = "Традиционное"
                },
                new DoughType
                {
                    Id = 2,
                    Name = "Тонкое"
                });

            modelBuilder
                .Entity<PizzaType>()
                .HasData(
                new PizzaType
                {
                    Id = 1,
                    Name = "Додо Микс",
                    Description = "Бекон , цыпленок , ветчина , сыры чеддер и пармезан , соус песто, кубики брынзы , томаты , красный лук , моцарелла, фирменный соус альфредо, чеснок , итальянские травы"
                },
                new PizzaType
                {
                    Id = 2,
                    Name = "Мясная",
                    Description = "Цыпленок , ветчина , пикантная пепперони , острые колбаски чоризо , моцарелла, фирменный томатный соус"
                },
                new PizzaType
                {
                    Id = 3,
                    Name = "Карбонара",
                    Description = "Бекон , сыры чеддер и пармезан , моцарелла, томаты , красный лук , чеснок , фирменный соус альфредо, итальянские травы "
                });

            var additives = new List<Additive>()
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

            modelBuilder
                .Entity<Additive>()
                .HasData(additives);

            var carbonaras = new List<Pizza>()
            {
                new Pizza
                {
                    Id = 1,
                    PizzaTypeId = 3,
                    PizzaSizeId = 1,
                    DoughTypeId = 1,
                    Image = "CarbonaraSmall.png",
                    Price = 549,
                    Weight = 410,
                },
                new Pizza
                {
                    Id = 2,
                    PizzaTypeId = 3,
                    PizzaSizeId = 2,
                    DoughTypeId = 1,
                    Image = "CarbonaraMedium.png",
                    Price = 859,
                    Weight = 410,
                },
                new Pizza
                {
                    Id = 3,
                    PizzaTypeId = 3,
                    PizzaSizeId = 3,
                    DoughTypeId = 1,
                    Image = "CarbonaraBig.png",
                    Price = 999,
                    Weight = 410,
                },
                new Pizza
                {
                    Id = 4,
                    PizzaTypeId = 3,
                    PizzaSizeId = 2,
                    DoughTypeId = 2,
                    Image = "CarbonaraMediumThin.png",
                    Price = 859,
                    Weight = 410,
                },
                new Pizza
                {
                    Id = 5,
                    PizzaTypeId = 3,
                    PizzaSizeId = 3,
                    DoughTypeId = 2,
                    Image = "CarbonaraBigThin.png",
                    Price = 999,
                    Weight = 410,
                },
            };
            var meats = new List<Pizza>()
            {
                new Pizza
                {
                    Id = 6,
                    PizzaTypeId = 2,
                    PizzaSizeId = 1,
                    DoughTypeId = 1,
                    Image = "MeatSmall.png",
                    Price = 499,
                    Weight = 390,
                },
                new Pizza
                {
                    Id = 7,
                    PizzaTypeId = 2,
                    PizzaSizeId = 2,
                    DoughTypeId = 1,
                    Image = "MeatMedium.png",
                    Price = 769,
                    Weight = 590,
                },
                new Pizza
                {
                    Id = 8,
                    PizzaTypeId = 2,
                    PizzaSizeId = 3,
                    DoughTypeId = 1,
                    Image = "MeatBig.png",
                    Price = 899,
                    Weight = 820,
                },
                new Pizza
                {
                    Id = 9,
                    PizzaTypeId = 2,
                    PizzaSizeId = 2,
                    DoughTypeId = 2,
                    Image = "MeatMediumThi.png",
                    Price = 769,
                    Weight = 490,
                },
                new Pizza
                {
                    Id = 10,
                    PizzaTypeId = 2,
                    PizzaSizeId = 3,
                    DoughTypeId = 2,
                    Image = "MeatBigThin.png",
                    Price = 899,
                    Weight = 700,
                }
            };
            var mixes = new List<Pizza>()
            {
                new Pizza
                {
                    Id = 11,
                    PizzaTypeId = 2,
                    PizzaSizeId = 1,
                    DoughTypeId = 1,
                    Image = "MixSmall.png",
                    Price = 499,
                    Weight = 400,
                },
                new Pizza
                {
                    Id = 12,
                    PizzaTypeId = 2,
                    PizzaSizeId = 2,
                    DoughTypeId = 1,
                    Image = "MixMedium.png",
                    Price = 769,
                    Weight = 610,
                },
                new Pizza
                {
                    Id = 13,
                    PizzaTypeId = 2,
                    PizzaSizeId = 3,
                    DoughTypeId = 1,
                    Image = "MixBig.png",
                    Price = 899,
                    Weight = 830,
                },
                new Pizza
                {
                    Id = 14,
                    PizzaTypeId = 2,
                    PizzaSizeId = 2,
                    DoughTypeId = 2,
                    Image = "MixMediumThin.png",
                    Price = 769,
                    Weight = 490,
                },
                new Pizza
                {
                    Id = 15,
                    PizzaTypeId = 2,
                    PizzaSizeId = 3,
                    DoughTypeId = 2,
                    Image = "MixBigThin.png",
                    Price = 899,
                    Weight = 700,
                }
            };

            var pizzas = new List<Pizza>();

            pizzas.AddRange(carbonaras);
            pizzas.AddRange(meats);
            pizzas.AddRange(mixes);

            modelBuilder
                .Entity<Pizza>()
                .HasData(pizzas);

            var carbonaraAdditives = additives.Take(5).ToList();
            var meatAdditives = additives.Take(3).ToList();
            var mixAdditives = additives.Take(4).ToList();

            var pizzaAdditives = new List<PizzaAdditive>();
            var id = 1;
            var linkPizzaAndAdditives = (List<Pizza> pizzas1, List<Additive> additives1) =>
            {
                foreach (var pizza in pizzas1)
                {
                    foreach (var additive in additives1)
                    {
                        pizzaAdditives.Add(new PizzaAdditive
                        {
                            Id = id++,
                            AdditivesId = additive.Id,
                            PizzasId = pizza.Id,
                        });
                    }
                }
            };

            linkPizzaAndAdditives(carbonaras, carbonaraAdditives);
            linkPizzaAndAdditives(meats, meatAdditives);
            linkPizzaAndAdditives(mixes, mixAdditives);

            modelBuilder
                .Entity<Pizza>()
                .HasMany(s => s.Additives)
                .WithMany(s => s.Pizzas)
                .UsingEntity<PizzaAdditive>(j => j.HasData(pizzaAdditives));

            modelBuilder
                .Entity<ProductType>()
                .HasData(new ProductType[]
                {
                    new ProductType
                    {
                        Id = 1,
                        Name = "Завтрак"
                    },
                    new ProductType
                    {
                        Id = 2,
                        Name = "Закуски"
                    }
                });

            modelBuilder
                .Entity<SimpleProduct>()
                .HasData(new SimpleProduct[]
                {
                    new SimpleProduct
                    {
                        Id = 1,
                        Name = "Омлет с беконом",
                        Description = "Классическое сочетание горячего омлета с поджаристой корочкой и бекона с добавлением моцареллы и томатов на завтрак",
                        Count = 1,
                        CountMeasurement = "шт",
                        ProductTypeId = 1,
                        Weight = 130,
                        Image = "omelette1.png"
                    },
                    new SimpleProduct
                    {
                        Id = 2,
                        Name = "Омлет с ветчиной и грибами",
                        Description = "Горячий сытный омлет с поджаристой корочкой, ветчина, шампиньоны и моцарелла",
                        Count = 1,
                        CountMeasurement = "шт",
                        ProductTypeId = 1,
                        Weight = 110,
                        Image = "omelette2.png"
                    },
                    new SimpleProduct
                    {
                        Id = 3,
                        Name = "Омлет с пепперони",
                        Description = "Сытный и сбалансированный завтрак — омлет с поджаристой корочкой, пикантная пепперони, томаты и моцарелла",
                        Count = 1,
                        CountMeasurement = "шт",
                        ProductTypeId = 1,
                        Weight = 110,
                        Image = "omelette3.png"
                    },
                    new SimpleProduct
                    {
                        Id = 4,
                        Name = "Дэнвич ветчина и сыр",
                        Description = "Сытный и сбалансированный завтрак — омлет с поджаристой корочкой, пикантная пепперони, томаты и моцарелла",
                        Count = 1,
                        CountMeasurement = "шт",
                        ProductTypeId = 2,
                        Weight = 210,
                        Image = "denvich1.png"
                    },
                    new SimpleProduct
                    {
                        Id = 5,
                        Name = "Дэнвич чоризо барбекю",
                        Description = "Насыщенный вкус острых колбасок чоризо и пикантной пепперони с соусами бургер и барбекю, свежими томатами, маринованными огурчиками, моцареллой и луком в румяной чиабатте",
                        Count = 1,
                        CountMeasurement = "шт",
                        ProductTypeId = 2,
                        Weight = 210,
                        Image = "denvich2.png"
                    },
                    new SimpleProduct
                    {
                        Id = 6,
                        Name = "Паста Карбонара",
                        Description = "Паста из печи с беконом, сырами чеддер и пармезан, томатами, моцареллой, фирменным соусом альфредо и чесноком",
                        Count = 1,
                        CountMeasurement = "шт",
                        ProductTypeId = 2,
                        Weight = 350,
                        Image = "denvich3.png"
                    }
                });
        }
    }
}
