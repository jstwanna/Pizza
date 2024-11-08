using Catalog.Domain.Services;
using MassTransit;
using Pizza.Infrastructure.Rabbit.Catalog.Requests;
using Pizza.Infrastructure.Rabbit.Catalog.Responses;

namespace Catalog.Api.Consumers
{
    public class GetCategoryItemsConsumer : IConsumer<GetCatalogItemsRequest>
    {
        private readonly ICatalogService catalogService;

        public GetCategoryItemsConsumer(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        public async Task Consume (ConsumeContext<GetCatalogItemsRequest> context)
        {
            await context.RespondAsync(new GetCatalogItemsResponse
            {
                Items = await catalogService.GetCatalogItems(context.CancellationToken)
            });
        }
    }
}
