using Catalog.Domain.Services;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.Infrastructure.Rabbit.Catalog.Requests;
using Pizza.Infrastructure.Rabbit.Catalog.Responses;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ICatalogService catalogService;

        public CatalogController(IPublishEndpoint publishEndpoint, ICatalogService catalogService)
        {
            this.publishEndpoint = publishEndpoint;
            this.catalogService = catalogService;
        }

        //[HttpPost]
        //public async Task<IActionResult> GetAllProducts (GetAllItemsRequest request)
        //{
        //    var response = await

        //    return Ok();
        //}
    }
}
