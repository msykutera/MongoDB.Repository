# MongoDB.Repository
Repository pattern based on offical MongoDB.Driver for .NET

It is published as Nuget package [MongoDB.Driver.Repository](https://www.nuget.org/packages/MongoDB.Driver.Repository/).

Project MongoDB.Repository.Example contains simple example of how to use this library in .NET Core web projects.

Bascially to get it working:

1) Add two lines below to ConfigureServices method in Startup.cs
```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddSingleton(x => Configuration.GetSection("MongoDb").Get<MongoDbSettings>());
        services.AddScoped<IMongoDbContext, MongoDbContext>();
    }
```
2) Add section below to main configuration object in appsettings.json
```json
  "MongoDb": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "example"
  },
```
3) Then you can register repositories in ConfigureServices method in Startup.cs
```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddScoped<IRepository<Category>, BaseRepository<Category>>();
    }
```
4) Now you can inject repositories into services and controllers
```csharp
    private readonly IRepository<Category> _categoryRepository;

    public CategoriesController(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
     // ...
```
