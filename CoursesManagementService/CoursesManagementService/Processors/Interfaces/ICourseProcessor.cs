using CoursesManagementService.Models.Views;

namespace CoursesManagementService.Processors.Interfaces
{
    /// <summary>
    /// Processor for <see cref="Course"/> entities
    /// </summary>
    public interface ICourseProcessor
    {
        /// <summary>
        /// Add course to db
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task CreateCourseAsync(Course course);

        /// <summary>
        /// Add courses to db
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        Task CreateCoursesAsync(List<Course> courses);

        /// <summary>
        /// Get all courses
        /// </summary>
        Task<List<Course>> GetCoursesAsync();

        /// <summary>
        /// Get courses by ids
        /// </summary>
        Task<List<Course>> GetCoursesByIdsAsync(List<string> ids);
    }
}
