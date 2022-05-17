using MongoDB.Driver;
using MongoDb.Models;

namespace MongoDb.Repository.Interfaces
{
    public interface IMongoConnection
    {
        MongoDbSettings MongoDbSettings { get; }

        MongoClient Client { get; }

        IMongoDatabase Database { get; set; }
    }

}
