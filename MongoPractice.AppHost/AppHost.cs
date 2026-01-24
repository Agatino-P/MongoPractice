var builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<ProjectResource> api = builder.AddProject<Projects.MongoPractice_Api>("api");

builder.Build().Run();