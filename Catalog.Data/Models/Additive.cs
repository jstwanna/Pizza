﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Models
{
    public class Additive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public List<Product> Products { get; set; } = new();
        public List<ProductAdditive> ProductAdditives { get; set; } = new();
    }
}
