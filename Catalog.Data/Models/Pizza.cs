using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Models
{
    internal class Pizza
    {
        public int Id { get; set; }
        public string Image {  get; set; }
        public string Components {  get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }

        public int TypeId { get; set; }
        public PizzaType PizzaType { get; set; }
        
        public int DoughId { get; set; }
        public DoughType DoughType { get; set; }
    }
}
