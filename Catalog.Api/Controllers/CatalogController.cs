using Catalog.Domain.Models;
using Catalog.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        [HttpGet]
        public Task<CatalogItemListView[]> GetCatalogItems (CancellationToken cancellationToken)
        {
            return catalogService.GetCatalogItems(cancellationToken);
        }

        [HttpGet]
        public Task<string[]> GetCategoryListItems (CancellationToken cancellationToken)
        {
            return catalogService.GetCategoriesList(cancellationToken);
        }

        [HttpPost]
        [Authorize]
        public string TestAuth ()
        {
            return "Ok";
        }
    }
}
