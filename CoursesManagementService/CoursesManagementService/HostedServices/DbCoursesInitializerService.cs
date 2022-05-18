using CoursesManagementService.Models.Views;
using CoursesManagementService.Processors.Interfaces;
using Newtonsoft.Json;

namespace CoursesManagementService.HostedServices
{
    /// <summary>
    /// Hosted service responsible for initializing the database at startup if empty
    /// </summary>
    public class DbCoursesInitializerService : IHostedService
    {
        private readonly ICourseProcessor _courseProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="courseProcessor"></param>
        public DbCoursesInitializerService(ICourseProcessor courseProcessor)
        {
            _courseProcessor = courseProcessor;
        }

        /// <summary>
        /// Check db status and populate course db if it's empty
        /// </summary>
        /// <param name="cancellationToken"></param>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var courses = await _courseProcessor.GetCoursesAsync();
            if (courses?.Count > 0)
            {
                return;
            }

            var localCoursesJson = await File.ReadAllTextAsync("courses.json", cancellationToken);
            var localCourses = JsonConvert.DeserializeObject<List<Course>>(localCoursesJson);
            
            await _courseProcessor.CreateCoursesAsync(localCourses!);
        }

        /// <inheritdoc />
        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
