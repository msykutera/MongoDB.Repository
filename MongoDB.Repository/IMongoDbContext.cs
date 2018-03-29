using MongoDB.Driver;

namespace MongoDB.Repository
{
    public interface IMongoDbContext
    {
        IMongoDatabase Database { get; }
    }
}