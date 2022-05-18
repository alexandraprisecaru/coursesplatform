using MongoDB.Driver;
using MongoDb.Models;

namespace MongoDb.Repository.Interfaces
{
    /// <summary>
    /// Responsible for setting up the mongo connection
    /// </summary>
    public interface IMongoConnection
    {
        /// <summary>
        /// Mongo db settings
        /// </summary>
        MongoDbSettings MongoDbSettings { get; }

        /// <summary>
        /// Mongo client
        /// </summary>
        MongoClient Client { get; }

        /// <summary>
        /// Mongo database
        /// </summary>
        IMongoDatabase Database { get; set; }
    }
}
