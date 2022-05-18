using AutoMapper;
using CoursesManagementService.Models.Domain;
using CoursesManagementService.Models.Views;
using CoursesManagementService.Processors.Interfaces;
using MongoDB.Driver;
using MongoDb.Repository.Interfaces;

namespace CoursesManagementService.Processors
{
    /// <inheritdoc />
    public class CourseProcessor : ICourseProcessor
    {
        private readonly IRepository<CourseDomain> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Course repository</param>
        /// <param name="mapper">Domain-view mapper</param>
        public CourseProcessor(IRepository<CourseDomain> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task CreateCourseAsync(Course course)
        {
            var courseDomain = _mapper.Map<CourseDomain>(course);
            var filter = _repository.Filter.Eq(x => x.Name, courseDomain.Name);

            if (string.IsNullOrWhiteSpace(courseDomain.Id))
                await _repository.Collection.InsertOneAsync(courseDomain);
            else
                await _repository.Collection.ReplaceOneAsync(filter, courseDomain, new ReplaceOptions { IsUpsert = true });
        }

        /// <inheritdoc />
        public async Task CreateCoursesAsync(List<Course> courses)
        {
            await _repository.Collection.InsertManyAsync(courses.ConvertAll(x => _mapper.Map<CourseDomain>(x)));
        }

        /// <inheritdoc />
        public async Task<List<Course>> GetCoursesAsync()
        {
            return (await (await _repository.Collection.FindAsync(_repository.Filter.Empty))
                .ToListAsync())
                .ConvertAll(x => _mapper.Map<Course>(x))
                .ToList();
        }

        /// <inheritdoc />
        public async Task<List<Course>> GetCoursesByIdsAsync(List<string> ids)
        {
            var filter = _repository.Filter.Where(x => ids.Contains(x.Id));

            return (await (await _repository.Collection.FindAsync(filter))
                    .ToListAsync())
                .ConvertAll(x => _mapper.Map<Course>(x))
                .ToList();
        }
    }
}
