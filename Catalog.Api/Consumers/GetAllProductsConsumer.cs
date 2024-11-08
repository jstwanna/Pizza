using Catalog.Domain.Services;
using MassTransit;
using Pizza.Infrastructure.Rabbit.Catalog.Requests;
using Pizza.Infrastructure.Rabbit.Catalog.Responses;

namespace Catalog.Api.Consumers
{
    public class GetAllProductsConsumer : IConsumer<GetCatalogItemsRequest>
    {
        private readonly ICatalogService catalogService;

        public GetAllProductsConsumer(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        public async Task Consume (ConsumeContext<GetCatalogItemsRequest> context)
        {
            await context.RespondAsync(new GetCatalogItemsResponse
            {
                Products = await catalogService.GetCatalogItems(context.CancellationToken)
            });
        }
    }
}
