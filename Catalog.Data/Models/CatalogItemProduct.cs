using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Models
{
    public class CatalogItemProduct
    {
        public int Id { get; set; }

        public int CatalogItemId { get; set; }
        public CatalogItem CatalogItem { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
