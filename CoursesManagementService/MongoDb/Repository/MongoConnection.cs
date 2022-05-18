using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDb.Models;
using MongoDb.Repository.Interfaces;

namespace MongoDb.Repository
{
    /// <inheritdoc />
    public class MongoConnection : IMongoConnection
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mongoDbSettings"></param>
        public MongoConnection(IOptions<MongoDbSettings> mongoDbSettings)
        {
            MongoDbSettings = mongoDbSettings.Value;

            Client = new MongoClient(MongoDbSettings.ConnectionString);
            Database = Client.GetDatabase(MongoDbSettings.Database);
        }

        /// <inheritdoc />
        public MongoDbSettings MongoDbSettings { get; protected set; }

        /// <inheritdoc />
        public MongoClient Client { get; protected set; }

        /// <inheritdoc />
        public IMongoDatabase Database { get; set; }
    }
}
