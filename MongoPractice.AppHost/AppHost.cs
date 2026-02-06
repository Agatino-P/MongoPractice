using MongoPractice.ServiceDefaults;

var builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<MongoDBServerResource> mongo = builder.AddMongoDB("mongo")
    .WithDataVolume()
    .WithMongoExpress();

IResourceBuilder<MongoDBDatabaseResource> mongoDb = mongo.AddDatabase(ResourceNames.MongoDb);

IResourceBuilder<ProjectResource> api = builder.AddProject<Projects.MongoPractice_Api>("api")
    .WithReference(mongoDb)
    .WaitFor(mongoDb);

IResourceBuilder<ProjectResource> wasm=builder.AddProject<Projects.MogoPractice_Wasm>("wasm")
    .WithExternalHttpEndpoints()
    .WithReference(api)
    .WaitFor(api);

api.WithEnvironment("AllowedCorsOrigins", wasm.GetEndpoint("https"));

builder.Build().Run();