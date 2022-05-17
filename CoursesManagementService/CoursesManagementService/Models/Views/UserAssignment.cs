using CoursesManagementService.Models.Views;
using MongoDB.Bson.Serialization.Attributes;

namespace CoursesManagementService.Models
{
    public class UserAssignment
    {
        [BsonId]
        public string Id { get; set; }

        public List<string> CourseIds { get; set; }

        public string IdUser { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int WeeklyEstimate { get; set; }
    }
}
