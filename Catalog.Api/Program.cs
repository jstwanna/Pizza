using Catalog.Api.Consumers;
using Catalog.Data.Database;
using Catalog.Domain;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();

builder.AddNpgsqlDbContext<CatalogDbContext>("postgres-db");

var rabbitConnStr = builder.Configuration.GetConnectionString("rabbit");

builder.Services.AddMassTransit(cfg =>
{
    cfg.AddConsumer<GetCategoryItemsConsumer>();
    cfg.AddConsumer<GetCategoriesListConsumer>();

    cfg.UsingRabbitMq((context, rabbitCfg) =>
    {
        rabbitCfg.Host(rabbitConnStr);
        rabbitCfg.ConfigureEndpoints(context);

        rabbitCfg.ReceiveEndpoint("catalogQueue", e =>
        {
            e.ConfigureConsumer<GetCategoryItemsConsumer>(context);
            e.ConfigureConsumer<GetCategoriesListConsumer>(context);

            e.UseMessageRetry(u => u.Interval(3, 5));
        });
    });
});

builder.Services.AddCatalogServices();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
