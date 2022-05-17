using CoursesManagementService.Models;

namespace CoursesManagementService.Processors.Interfaces
{
    public interface ICourseAssignmentsProcessor
    {
        Task AssignCoursesAsync(UserAssignment userAssignment);
        Task<List<UserAssignment>> GetUserAssignmentsAsync(string userId);
    }
}
