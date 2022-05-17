using MongoDB.Driver;

namespace MongoDb.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IMongoCollection<T> Collection { get; }

        FilterDefinitionBuilder<T> Filter { get; }
        SortDefinitionBuilder<T> Sort { get; }
    }
}
