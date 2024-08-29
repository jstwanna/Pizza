using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Infrastructure.Models
{
    public class PizzaView
    {
        public string Image { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string PizzaType { get; set; }
        public string DoughType { get; set; }
        public string PizzaSize { get; set; }
        public IEnumerable<AdditiveView> Additives { get; set; }
    }
}
