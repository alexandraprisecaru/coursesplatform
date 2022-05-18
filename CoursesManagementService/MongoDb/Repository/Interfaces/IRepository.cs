using MongoDB.Driver;

namespace MongoDb.Repository.Interfaces
{
    /// <summary>
    /// Repository class for <see cref="T"/> entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Collection
        /// </summary>
        IMongoCollection<T> Collection { get; }

        /// <summary>
        /// Filter
        /// </summary>
        FilterDefinitionBuilder<T> Filter { get; }
    }
}
