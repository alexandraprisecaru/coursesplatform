using CoursesManagementService.Models.Views;
using CoursesManagementService.Processors.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoursesManagementService.Controllers
{
    /// <summary>
    /// Controller class for <see cref="UserCourseAssignment"/> entities
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CourseAssignmentController : Controller
    {
        private readonly ICourseAssignmentsProcessor _userAssignmentProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userAssignmentProcessor">Processor for <see cref="UserCourseAssignment"/></param>
        public CourseAssignmentController(ICourseAssignmentsProcessor userAssignmentProcessor)
        {
            _userAssignmentProcessor = userAssignmentProcessor;
        }

        /// <summary>
        /// Assign courses to user
        /// </summary>
        /// <param name="userAssignment">User Course Assignment</param>
        [HttpPost]
        public async Task<IActionResult> AssignCoursesToUser([FromBody] UserCourseAssignment userAssignment)
        {
            return Ok(await _userAssignmentProcessor.AssignCoursesAsync(userAssignment));
        }

        /// <summary>
        /// Get all of the user's course assignments
        /// </summary>
        /// <param name="userId">User id</param>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserCourseAssignments([FromRoute] string userId)
        {
            return Ok(await _userAssignmentProcessor.GetUserAssignmentsAsync(userId));
        }
    }
}
