using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var rabbitUsername = builder.AddParameter("rabbitUsername", secret: true);
var rabbitPassword = builder.AddParameter("rabbitPassword", secret: true);

var rabbit = builder.AddRabbitMQ(
        name: "rabbit",
        userName: rabbitUsername,
        password: rabbitPassword,
        port: 5431)
    .WithManagementPlugin();

var elasticPass = builder.AddParameter("elasticPass", secret: true);

var elastic = builder.AddElasticsearch(
        name: "elastic", 
        password: elasticPass)
    .WithDataVolume();

var pgUsername = builder.AddParameter("pgUsername", secret: true);
var pgPassword = builder.AddParameter("pgPassword", secret: true);

var postgres = builder.AddPostgres(
        name: "postgres",
        userName: pgUsername,
        password: pgPassword,
        port: 5432)
    .WithDataVolume()
    .WithPgAdmin(s => s.WithHostPort(5430));

var postgresdb = postgres.AddDatabase("postgres-db");

var api = builder
    .AddProject<Projects.Pizza_Api>("pizza-api")
    .WithExternalHttpEndpoints()
    .WithReference(rabbit)
    .WithReference(postgresdb)
    .WithReference(elastic)
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
