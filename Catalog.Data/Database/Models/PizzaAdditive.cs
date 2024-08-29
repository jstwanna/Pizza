using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Database.Models
{
    public class PizzaAdditive
    {
        public int Id { get; set; }

        public int PizzasId { get; set; }
        [ForeignKey("PizzasId")]
        public Pizza Pizzas { get; set; }

        public int AdditivesId { get; set; }
        [ForeignKey("AdditivesId")]
        public Additive Additives { get; set; }
    }
}
