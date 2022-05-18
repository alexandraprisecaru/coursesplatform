using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoursesManagementService.Models.Domain
{
    /// <summary>
    /// Base domain class
    /// </summary>
    public class BaseDomain
    {
        /// <summary>
        /// Bson Id generated automatically by mongoDB
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
