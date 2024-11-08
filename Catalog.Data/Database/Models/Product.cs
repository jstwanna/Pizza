using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Database.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Image {  get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public List<Additive> Additives { get; set; } = new();
        public List<ProductAdditive> ProductAdditives { get; set; } = new();
        public List<Сharacteristic> Characteristics { get; set; } = new();
        public List<CatalogItem> CatalogItems { get; set; }
    }
}
