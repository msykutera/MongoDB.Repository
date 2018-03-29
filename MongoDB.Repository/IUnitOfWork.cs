using MongoDB.Driver;

namespace MongoDB.Repository
{
    public interface IUnitOfWork
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
    }
}