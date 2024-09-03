using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<GetAllItemsResponse> GetAllProducts (CancellationToken cancellationToken)
        {
            var response = await busControl.Request<GetAllItemsRequest, GetAllItemsResponse>(new GetAllItemsRequest(), cancellationToken);

            return response.Message;
        }
    }
}
