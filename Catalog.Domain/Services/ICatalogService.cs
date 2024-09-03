using Catalog.Data.Database.Models;
using Pizza.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Services
{
    public interface ICatalogService
    {
        public Task<PizzaListView[]> GetAllPizzas ();
        public Task<ProductListView[]> GetAllProducts ();
    }
}
