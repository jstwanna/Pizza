var builder = DistributedApplication.CreateBuilder(args);

var api = builder
    .AddProject<Projects.Pizza_Api>("pizza-api")
    .WithExternalHttpEndpoints();

var frontend = builder
    .AddNpmApp("pizza-frontend", "../Pizza.Frontend", "dev")
    .WithReference(api)
    .WithHttpEndpoint(env: "PORT", port: 5555)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
