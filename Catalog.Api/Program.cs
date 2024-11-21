using Catalog.Data;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();

builder.AddNpgsqlDbContext<CatalogDbContext>("catalog-db");

var rabbitConnStr = builder.Configuration.GetConnectionString("rabbit");

builder.Services.AddCatalogServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocument();

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
