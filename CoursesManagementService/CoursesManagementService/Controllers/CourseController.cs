using CoursesManagementService.Models;
using CoursesManagementService.Models.Views;
using CoursesManagementService.Processors.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoursesManagementService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseProcessor _courseProcessor;

        public CourseController(ICourseProcessor courseProcessor, ILogger<CourseController> logger)
        {
            _courseProcessor = courseProcessor;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await _courseProcessor.GetCoursesAsync());
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            await _courseProcessor.CreateCourseAsync(course);
            return Ok();
        }

        [HttpPost("add-multiple")]
        public async Task<IActionResult> AddCourses([FromBody] List<Course> courses)
        {
            await _courseProcessor.CreateCoursesAsync(courses);
            return Ok();
        }
    }
}