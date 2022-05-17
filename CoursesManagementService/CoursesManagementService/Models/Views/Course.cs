using System.ComponentModel.DataAnnotations;

namespace CoursesManagementService.Models.Views
{
    public class Course
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
