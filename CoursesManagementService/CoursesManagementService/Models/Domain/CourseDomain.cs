namespace CoursesManagementService.Models.Domain
{
    /// <summary>
    /// Course domain
    /// </summary>
    public class CourseDomain : BaseDomain
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Duration in hours
        /// </summary>
        public int Duration { get; set; }
    }
}
