namespace CoursesManagementService.Models.Domain
{
    public class UserAssignmentDomain : BaseDomain
    {
        public List<string> CourseIds { get; set; }

        public string IdUser { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int WeeklyEstimate { get; set; }

        public int TotalHours { get; set; }
    }
}
