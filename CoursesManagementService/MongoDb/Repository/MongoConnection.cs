using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDb.Models;
using MongoDb.Repository.Interfaces;

namespace MongoDb.Repository
{
    public class MongoConnection : IMongoConnection
    {
        public MongoConnection(IOptions<MongoDbSettings> mongoDbSettings)
        {
            MongoDbSettings = mongoDbSettings.Value;

            Client = new MongoClient(MongoDbSettings.ConnectionString);
            Database = Client.GetDatabase(MongoDbSettings.Database);

        }

        public MongoDbSettings MongoDbSettings { get; protected set; }

        public MongoClient Client { get; protected set; }

        public IMongoDatabase Database { get; set; }
    }
}
