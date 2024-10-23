using Microsoft.OpenApi.Models;
using MassTransit;

string devAllowCors = "dev_cors";

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
});
builder.Services.AddSwaggerDocument();

builder.AddSeqEndpoint("seq", cfg => cfg.DisableHealthChecks = true);

var rabbitConnStr = builder.Configuration.GetConnectionString("rabbit");

builder.Services.Configure<MassTransitHostOptions>(options =>
{
    options.WaitUntilStarted = true;
    options.StartTimeout = TimeSpan.FromSeconds(300);
});

builder.Services.AddMassTransit(cfg =>
{
    cfg.UsingRabbitMq((context, rabbitCfg) =>
    {
        rabbitCfg.Host(rabbitConnStr);
    });
});

builder.Services.AddCors(option =>
{
    option.AddPolicy(
        devAllowCors,
        p =>
        p
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin());
});

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseCors(devAllowCors);
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
