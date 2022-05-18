using CoursesManagementService.Models;
using CoursesManagementService.Processors.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoursesManagementService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseAssignmentController : Controller
    {
        private readonly ICourseAssignmentsProcessor _userAssignmentProcessor;

        public CourseAssignmentController(ICourseAssignmentsProcessor userAssignmentProcessor)
        {
            _userAssignmentProcessor = userAssignmentProcessor;
        }

        [HttpPost]
        public async Task<IActionResult> AssignCoursesToUser([FromBody] UserAssignment userAssignments)
        {
            return Ok(await _userAssignmentProcessor.AssignCoursesAsync(userAssignments));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserCourseAssignments([FromRoute] string userId)
        {
            return Ok(await _userAssignmentProcessor.GetUserAssignmentsAsync(userId));
        }
    }
}
