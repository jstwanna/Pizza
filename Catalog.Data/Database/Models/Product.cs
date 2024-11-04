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
        public ProductType Type { get; set; }
        public string Image {  get; set; }
        public double Price { get; set; }
    }
}
