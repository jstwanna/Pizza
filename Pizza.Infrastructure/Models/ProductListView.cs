using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Infrastructure.Models
{
    public class ProductListView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double Count { get; set; }
        public string CountMeasurement { get; set; }
        public string Image { get; set; }
        public string ProductType { get; set; }
    }
}
