using Catalog.Api.Consumers;
using Catalog.Data.Database;
using Catalog.Domain;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddNpgsqlDbContext<CatalogDbContext>("postgres-db");
//builder.AddRabbitMQClient("rabbit");

var rabbitConnStr = builder.Configuration.GetConnectionString("rabbit");

builder.Services.Configure<MassTransitHostOptions>(options =>
{
    options.WaitUntilStarted = true;
    options.StartTimeout = TimeSpan.FromSeconds(30);
    options.StopTimeout = TimeSpan.FromSeconds(1);
});

builder.Services.AddMassTransit(cfg =>
{
    cfg.AddConsumer<GetAllProductsConsumer>();

    cfg.UsingRabbitMq((context, rabbitCfg) =>
    {
        rabbitCfg.Host(rabbitConnStr);
        rabbitCfg.ConfigureEndpoints(context);

        rabbitCfg.ReceiveEndpoint("catalogQueue", e =>
        {
            e.ConfigureConsumer<GetAllProductsConsumer>(context);

            e.UseMessageRetry(u => u.Interval(3, 5));
        });
    });
});

builder.Services.AddCatalogServices();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
