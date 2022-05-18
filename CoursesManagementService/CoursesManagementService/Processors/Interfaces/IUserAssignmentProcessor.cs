using CoursesManagementService.Models.Views;

namespace CoursesManagementService.Processors.Interfaces
{
    /// <summary>
    /// Processor for <see cref="UserCourseAssignment"/> entities
    /// </summary>
    public interface ICourseAssignmentsProcessor
    {
        /// <summary>
        /// Assign courses to user and provide a weekly estimate
        /// </summary>
        /// <param name="userAssignment"></param>
        /// <returns>User course assignment with estimate established</returns>
        Task<UserCourseAssignment> AssignCoursesAsync(UserCourseAssignment userAssignment);

        /// <summary>
        /// Get all of the user's course assignments
        /// </summary>
        /// <param name="userId"></param>
        Task<List<UserCourseAssignment>> GetUserAssignmentsAsync(string userId);
    }
}
