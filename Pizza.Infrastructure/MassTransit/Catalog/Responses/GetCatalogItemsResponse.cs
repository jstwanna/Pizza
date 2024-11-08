using Pizza.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Infrastructure.Rabbit.Catalog.Responses
{
    public class GetCatalogItemsResponse
    {
        public CatalogItemListView[] Products { get; set; }
    }
}
