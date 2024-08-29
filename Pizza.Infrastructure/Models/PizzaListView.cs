using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Infrastructure.Models
{
    public class PizzaListView
    {
        public int Id { get; set; }
        public IEnumerable<PizzaView>? Pizzas { get; set; }
    }
}
