namespace CoursesManagementService.Models.Views
{
    /// <summary>
    /// User course assignment entity
    /// </summary>
    public class UserCourseAssignment
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Ids of the courses
        /// </summary>
        public List<string> CourseIds { get; set; }

        /// <summary>
        /// User id
        /// </summary>
        public string IdUser { get; set; }

        /// <summary>
        /// Starting date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Ending date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Estimated no. of hours dedicated per hour
        /// </summary>
        public int WeeklyEstimate { get; set; }

        /// <summary>
        /// Total no. of hours
        /// </summary>
        public int TotalHours { get; set; }
    }
}
