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
        public double Price { get; set; }
        public string ProductType { get; set; }
        public string Image {  get; set; }

        public CharacteristicsListView[] Characteristics { get; set; }
        public AdditiveListView[] Additives { get; set; }
    }
}
