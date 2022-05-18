using CoursesManagementService.Models.Views;
using CoursesManagementService.Processors.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoursesManagementService.Controllers
{

    /// <summary>
    /// Controller for <see cref="Course"/> entities
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseProcessor _courseProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="courseProcessor"></param>
        public CourseController(ICourseProcessor courseProcessor)
        {
            _courseProcessor = courseProcessor;
        }

        /// <summary>
        /// Get all courses available
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await _courseProcessor.GetCoursesAsync());
        }

        /// <summary>
        /// Get courses by ids
        /// </summary>
        /// <param name="ids">ids of the courses</param>
        [HttpGet]
        public async Task<IActionResult> GetCoursesByIds([FromBody] List<string> ids)
        {
            return Ok(await _courseProcessor.GetCoursesByIdsAsync(ids));
        }

        /// <summary>
        /// Add course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            await _courseProcessor.CreateCourseAsync(course);
            return Ok();
        }

        /// <summary>
        /// Add multiples courses
        /// </summary>
        /// <param name="courses">list of courses</param>
        [HttpPost("add-multiple")]
        public async Task<IActionResult> AddCourses([FromBody] List<Course> courses)
        {
            await _courseProcessor.CreateCoursesAsync(courses);
            return Ok();
        }
    }
}