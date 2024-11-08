using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.Infrastructure.MassTransit.Catalog.Requests;
using Pizza.Infrastructure.MassTransit.Catalog.Responses;
using Pizza.Infrastructure.Rabbit.Catalog.Requests;
using Pizza.Infrastructure.Rabbit.Catalog.Responses;

namespace Pizza.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IBusControl busControl;

        public CatalogController(IBusControl busControl)
        {
            this.busControl = busControl;
        }

        [HttpPost]
        public async Task<GetCatalogItemsResponse> GetCatalogItems (CancellationToken cancellationToken)
        {
            var response = await busControl.Request<GetCatalogItemsRequest, GetCatalogItemsResponse>(new(), cancellationToken);

            return response.Message;
        }

        [HttpPost]
        public async Task<GetCategoryListResponse> GetCategories (CancellationToken cancellationToken)
        {
            var response = await busControl.Request<GetCategoryListRequest, GetCategoryListResponse>(new(), cancellationToken);

            return response.Message;
        }
    }
}
