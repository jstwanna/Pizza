using Catalog.Domain.Services;
using MassTransit;
using Pizza.Infrastructure.MassTransit.Catalog.Requests;
using Pizza.Infrastructure.MassTransit.Catalog.Responses;
using Pizza.Infrastructure.Rabbit.Catalog.Requests;
using Pizza.Infrastructure.Rabbit.Catalog.Responses;

namespace Catalog.Api.Consumers
{
    public class GetCategoriesListConsumer : IConsumer<GetCategoryListRequest>
    {
        private readonly ICatalogService catalogService;

        public GetCategoriesListConsumer(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        public async Task Consume (ConsumeContext<GetCategoryListRequest> context)
        {
            await context.RespondAsync(new GetCategoryListResponse
            {
                Categories = await catalogService.GetCategoriesList(context.CancellationToken)
            });
        }
    }
}
