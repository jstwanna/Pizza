using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Database.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }

        public int PizzaTypeId { get; set; }
        [ForeignKey("PizzaTypeId")]
        public PizzaType PizzaType { get; set; }

        public int DoughTypeId { get; set; }
        [ForeignKey("DoughTypeId")]
        public DoughType DoughType { get; set; }

        public int PizzaSizeId { get; set; }
        [ForeignKey("PizzaSizeId")]
        public PizzaSize PizzaSize { get; set; }

        public List<Additive> Additives { get; set; } = new();
    }
}
