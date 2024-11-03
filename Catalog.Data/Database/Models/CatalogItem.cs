using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Database.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public int ComboTypeId { get; set; }
        public ComboType ComboType { get; set; }
        
        public int CatalogCategoryId { get; set; }
        public CatalogCategory CatalogCategory { get; set; }
    }
}
