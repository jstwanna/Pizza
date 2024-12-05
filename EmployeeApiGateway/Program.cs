using Ocelot.Middleware;
using Ocelot.DependencyInjection;

string devAllowCors = "dev_cors";

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();

builder.AddSeqEndpoint("seq", cfg => cfg.DisableHealthChecks = true);

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

builder.Configuration.AddJsonFile("ocelot.json", true, true);
builder.Services.AddOcelot();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors(devAllowCors);
    app.UseSwaggerForOcelotUI();
}

app.UseOcelot().Wait();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
