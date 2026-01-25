using MongoPractice.ServiceDefaults;

var builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<MongoDBServerResource> mongo = builder.AddMongoDB("mongo")
    .WithDataVolume()
    .WithMongoExpress();

IResourceBuilder<MongoDBDatabaseResource> mongoDb = mongo.AddDatabase(ResourceNames.MongoDb);

IResourceBuilder<ProjectResource> api = builder.AddProject<Projects.MongoPractice_Api>("api")
    .WithReference(mongoDb);

builder.Build().Run();