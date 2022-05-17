using System.Text.RegularExpressions;
using MongoDB.Driver;
using MongoDb.Models;
using MongoDb.Repository.Interfaces;

namespace MongoDb.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly IMongoConnection _connection;
        private readonly MongoDbSettings _mongoDbSettings;
        private readonly string _collectionName;

        public IMongoCollection<T> Collection { get; }
        public virtual FilterDefinitionBuilder<T> Filter => Builders<T>.Filter;
        public virtual SortDefinitionBuilder<T> Sort => Builders<T>.Sort;

        public Repository(IMongoConnection mongoConnection)
        {
            _collectionName = Regex.Replace(typeof(T).Name, "domain", "", RegexOptions.IgnoreCase);
            _connection = mongoConnection;
            _mongoDbSettings = mongoConnection.MongoDbSettings;

            Collection = mongoConnection.Database.GetCollection<T>(_collectionName);
        }
    }
}
