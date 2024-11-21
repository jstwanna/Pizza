using Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.SeedData
{
    internal class CatalogItemSeedData
    {
        public static List<CatalogItem> GetCatalogItems()
        {
            return new()
            {
                new CatalogItem
                {
                    Id = 1,
                    CatalogCategoryId = 1,
                    ViewTypeId = 1,
                    Image = "CarbonaraMedium.png",
                    Name = "Карбонара",
                    Description = "Бекон, сыры чеддер и пармезан, моцарелла, томаты, красный лук, чеснок, фирменный соус альфредо, итальянские травы"
                },
                new CatalogItem
                {
                    Id = 2,
                    CatalogCategoryId = 3,
                    ViewTypeId = 3,
                    Image = "denvich1.png",
                    Name = "Дэнвич ветчина и сыр",
                    Description = "Поджаристая чиабатта и знакомое сочетание ветчины, цыпленка, моцареллы со свежими томатами, соусом ранч и чесноком"
                },
                new CatalogItem
                {
                    Id = 3,
                    CatalogCategoryId = 3,
                    ViewTypeId = 3,
                    Image = "denvich2.png",
                    Name = "Дэнвич чоризо барбекю",
                    Description = "Насыщенный вкус острых колбасок чоризо и пикантной пепперони с соусами бургер и барбекю, свежими томатами, маринованными огурчиками, моцареллой и луком в румяной чиабатте"
                },
                new CatalogItem
                {
                    Id = 4,
                    CatalogCategoryId = 3,
                    ViewTypeId = 3,
                    Image = "denvich3.png",
                    Name = "Паста Карбонара",
                    Description = "Паста из печи с беконом, сырами чеддер и пармезан, томатами, моцареллой, фирменным соусом альфредо и чесноком"
                },
                new CatalogItem
                {
                    Id = 5,
                    CatalogCategoryId = 1,
                    ViewTypeId = 1,
                    Image = "MeatMedium.png",
                    Name = "Мясная",
                    Description = "Цыпленок, ветчина, пикантная пепперони, острые колбаски чоризо, моцарелла, фирменный томатный соус"
                },
                new CatalogItem
                {
                    Id = 6,
                    CatalogCategoryId = 1,
                    ViewTypeId = 1,
                    Image = "MixMedium.png",
                    Name = "Додо микс",
                    Description = "Бекон, цыпленок, ветчина, сыры чеддер и пармезан, соус песто, кубики брынзы, томаты, красный лук, моцарелла, фирменный соус альфредо, чеснок, итальянские травы"
                },
                new CatalogItem
                {
                    Id = 7,
                    CatalogCategoryId = 4,
                    ViewTypeId = 3,
                    Image = "omelette1.png",
                    Name = "Омлет с беконом",
                    Description = "Классическое сочетание горячего омлета с поджаристой корочкой и бекона с добавлением моцареллы и томатов на завтрак"
                },
                new CatalogItem
                {
                    Id = 8,
                    CatalogCategoryId = 4,
                    ViewTypeId = 3,
                    Image = "omelette2.png",
                    Name = "Омлет с ветчиной и грибами",
                    Description = "Горячий сытный омлет с поджаристой корочкой, ветчина, шампиньоны и моцарелла"
                },
                new CatalogItem
                {
                    Id = 9,
                    CatalogCategoryId = 4,
                    ViewTypeId = 3,
                    Image = "omelette3.png",
                    Name = "Омлет с пепперони",
                    Description = "Сытный и сбалансированный завтрак — омлет с поджаристой корочкой, пикантная пепперони, томаты и моцарелла"
                },
                //new CatalogItem
                //{
                //    Id = 10,
                //    CatalogCategoryId = 2,
                //    ViewTypeId = 2,
                //    Image = "Combo3Pizzas.png",
                //    Name = "3 пиццы",
                //    Description = "Три удовольствия в нашем меню — это 3 средние пиццы на ваш выбор. Цена комбо зависит от выбранных пицц и может быть увеличена"
                //},
            };
        }
    }
}
