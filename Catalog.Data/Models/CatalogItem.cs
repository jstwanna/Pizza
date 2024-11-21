using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ViewTypeId { get; set; }
        public ViewType ViewType { get; set; }

        public int CatalogCategoryId { get; set; }
        public CatalogCategory CatalogCategory { get; set; }

        public List<Product> Products { get; set; }
    }
}
