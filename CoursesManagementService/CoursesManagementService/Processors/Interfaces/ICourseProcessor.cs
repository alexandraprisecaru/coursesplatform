using CoursesManagementService.Models;
using CoursesManagementService.Models.Views;

namespace CoursesManagementService.Processors.Interfaces
{
    public interface ICourseProcessor
    {
        Task CreateCourseAsync(Course course);
        Task CreateCoursesAsync(List<Course> courses);
        Task<List<Course>> GetCoursesAsync();
        
    }
}
