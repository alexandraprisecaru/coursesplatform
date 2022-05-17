using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoursesManagementService.Models.Domain
{
    public class BaseDomain
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
