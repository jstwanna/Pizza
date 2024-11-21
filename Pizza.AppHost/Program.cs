using Aspirant.Hosting;
using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var rabbitUsername = builder.AddParameter("rabbitUsername", secret: true);
var rabbitPassword = builder.AddParameter("rabbitPassword", secret: true);

var rabbit = builder.AddRabbitMQ(
        name: "rabbit",
        userName: rabbitUsername,
        password: rabbitPassword,
        port: 5431)
    .WithManagementPlugin(port: 5435);

var seq = builder
    .AddSeq("seq", 5434)
    .WithDataVolume("seq_data");

var pgUsername = builder.AddParameter("pgUsername", secret: true);
var pgPassword = builder.AddParameter("pgPassword", secret: true);

var postgres = builder.AddPostgres(
        name: "postgres",
        userName: pgUsername,
        password: pgPassword,
        port: 5432)
    .WithDataVolume("postgres_data")
    .WithPgAdmin(s => s.WithHostPort(5430));

var catalogdb = postgres.AddDatabase("catalog-db", "catalog");
var identitydb = postgres.AddDatabase("identity-db", "identity");

var identityService = builder
    .AddProject<Projects.Identity_Api>("identity-service")
    .WithReference(identitydb);

var catalogService = builder
    .AddProject<Projects.Catalog_Api>("catalog-service")
    .WithReference(catalogdb)
    .WithReference(rabbit);

var media = builder
    .AddProject<Projects.Pizza_Media>("media-server")
    .WithExternalHttpEndpoints();

var api = builder
    .AddProject<Projects.Client_ApiGateway>("client-api")
    .WithExternalHttpEndpoints()
    .WithReference(rabbit)
    .WithReference(seq)
    .WithReference(media)
    ;


if (builder.Environment.IsDevelopment())
{
    var clientFrontend = builder
        .AddNpmApp("client-frontend", "../Client.Frontend", "dev")
        .WithReference(api)
        .WithHttpEndpoint(env: "PORT", port: 8081)
        .WithExternalHttpEndpoints();

    var employeeFrontend = builder
        .AddNpmApp("employee-frontend", "../Employee.Frontend", "dev")
        .WithReference(api)
        .WithHttpEndpoint(env: "PORT", port: 8080)
        .WithExternalHttpEndpoints();
}

builder.Build().Run();
