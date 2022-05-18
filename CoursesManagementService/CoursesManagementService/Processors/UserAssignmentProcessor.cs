using System.Net;
using AutoMapper;
using CoursesManagementService.Models;
using CoursesManagementService.Models.Domain;
using CoursesManagementService.Processors.Interfaces;
using MongoDB.Driver;
using MongoDb.Repository.Interfaces;

namespace CoursesManagementService.Processors
{
    public class CourseAssignmentsProcessor : ICourseAssignmentsProcessor
    {

        private readonly IRepository<UserAssignmentDomain> _repository;
        private readonly IRepository<CourseDomain> _courseRepository;
        private readonly IMapper _mapper;

        public CourseAssignmentsProcessor(
            IRepository<UserAssignmentDomain> repository, 
            IRepository<CourseDomain> courseRepository,
            IMapper mapper)
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<UserAssignment> AssignCoursesAsync(UserAssignment userAssignment)
        {
            var userAssignmentDomain = _mapper.Map<UserAssignmentDomain>(userAssignment);
            var filter = _repository.Filter.Eq(x => x.Id, userAssignmentDomain.Id);

            var courses =
                await (await _courseRepository.Collection.FindAsync(_courseRepository.Filter.Where(x =>
                    userAssignmentDomain.CourseIds.Contains(x.Id)))).ToListAsync();

            if (courses == null || courses.Count != userAssignmentDomain.CourseIds.Count)
            {
                throw new BadHttpRequestException("Invalid list of courses!", (int)HttpStatusCode.NotFound);
            }

            var totalHours = courses.Select(x => x.Duration).Sum();
            userAssignmentDomain.TotalHours = totalHours;
            userAssignmentDomain.WeeklyEstimate = EstimateWeeklyHoursCount(userAssignmentDomain.StartDate, userAssignmentDomain.EndDate, totalHours);

            if (string.IsNullOrWhiteSpace(userAssignmentDomain.Id))
                await _repository.Collection.InsertOneAsync(userAssignmentDomain);
            else
                await _repository.Collection.ReplaceOneAsync(filter, userAssignmentDomain, new ReplaceOptions { IsUpsert = true });

            return _mapper.Map<UserAssignment>(userAssignmentDomain);
        }

        public async Task<List<UserAssignment>> GetUserAssignmentsAsync(string userId)
        {
            var filter = _repository.Filter.Eq(x => x.Id, userId);

            var userAssignmentDomains =await (await _repository.Collection.FindAsync(filter)).ToListAsync();

            return userAssignmentDomains.ConvertAll(x => _mapper.Map<UserAssignment>(x));
        }

        private int EstimateWeeklyHoursCount(DateTime startDate, DateTime endDate, int totalHours)
        {
            var days = (endDate - startDate).TotalDays;

            if (days <= 7)
            {
                return totalHours;
            }

            var weeks = days / 7;
            var result = totalHours / weeks;

            return (int)Math.Floor(result);
        }
    }
}
