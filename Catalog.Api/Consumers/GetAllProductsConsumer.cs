using Catalog.Domain.Services;
using MassTransit;
using Pizza.Infrastructure.Rabbit.Catalog.Requests;
using Pizza.Infrastructure.Rabbit.Catalog.Responses;

namespace Catalog.Api.Consumers
{
    public class GetAllProductsConsumer : IConsumer<GetAllItemsRequest>
    {
        private readonly ICatalogService catalogService;

        public GetAllProductsConsumer(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        public async Task Consume (ConsumeContext<GetAllItemsRequest> context)
        {
            var products = await catalogService.GetAllProducts();
            var pizzas = await catalogService.GetAllPizzas();

            await context.RespondAsync(new GetAllItemsResponse
            {
                Pizzas = pizzas,
                Products = products
            });
        }
    }
}
