using System.Text.RegularExpressions;
using MongoDB.Driver;
using MongoDb.Repository.Interfaces;

namespace MongoDb.Repository
{
    /// <inheritdoc />
    public class Repository<T> : IRepository<T>
    {
        /// <inheritdoc />
        public IMongoCollection<T> Collection { get; }
        public virtual FilterDefinitionBuilder<T> Filter => Builders<T>.Filter;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mongoConnection"></param>
        public Repository(IMongoConnection mongoConnection)
        {
            string collectionName = Regex.Replace(typeof(T).Name, "domain", "", RegexOptions.IgnoreCase);
            
            Collection = mongoConnection.Database.GetCollection<T>(collectionName);
        }
    }
}
