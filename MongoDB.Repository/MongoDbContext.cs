using MongoDB.Driver;

namespace MongoDB.Repository
{
    public class MongoDbContext : IMongoDbContext
    {
        public MongoDbContext(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            Database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoDatabase Database { get; }
    }
}