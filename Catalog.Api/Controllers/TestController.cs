using Catalog.Data.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly CatalogDbContext catalogDbContext;

        public TestController (CatalogDbContext catalogDbContext)
        {
            this.catalogDbContext = catalogDbContext;
        }

        [HttpPost]
        public void Test ()
        {
            var tt = catalogDbContext.PizzaSizes.ToList();
        }
    }
}
