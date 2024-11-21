using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Models
{
    public class CatalogItemListView
    {
        public string Category { get; set; }
        public string ViewType { get; set; }
        public string Image {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ProductListView[] Products { get; set; }
    }
}
