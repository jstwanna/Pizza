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

var postgresdb = postgres.AddDatabase("postgres-db", "postgres");

var identityService = builder
    .AddProject<Projects.Identity_Api>("identity-service")
    .WithReference(postgresdb)
    .WithReference(rabbit);

var catalogService = builder
    .AddProject<Projects.Catalog_Api>("catalog-service")
    .WithReference(postgresdb)
    .WithReference(rabbit);

var media = builder
    .AddProject<Projects.Pizza_Media>("media-server")
    .WithExternalHttpEndpoints();

var api = builder
    .AddProject<Projects.Client_ApiGateway>("client-api")
    .WithExternalHttpEndpoints()
    .WithReference(rabbit)
    .WithReference(seq)
    .WithReference(catalogService)
    .WithReference(identityService)
    .WithReference(media)
    ;

if (builder.Environment.IsDevelopment())
{
    var frontend = builder
        .AddNpmApp("pizza-frontend", "../Pizza.Frontend", "dev")
        .WithReference(api)
        .WithHttpEndpoint(env: "PORT", port: 8080)
        .WithExternalHttpEndpoints();
}

builder.Build().Run();
