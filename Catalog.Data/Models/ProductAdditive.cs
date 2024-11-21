using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Models
{
    public class ProductAdditive
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int AdditiveId { get; set; }
        public Additive Additive { get; set; }
    }
}
