using System.ComponentModel.DataAnnotations;

namespace CoursesManagementService.Models.Views
{
    /// <summary>
    /// Course
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Duration in hours
        /// </summary>
        [Required]
        public int Duration { get; set; }
    }
}
