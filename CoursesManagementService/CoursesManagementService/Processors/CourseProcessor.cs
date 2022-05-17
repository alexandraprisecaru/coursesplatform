using AutoMapper;
using CoursesManagementService.Models;
using CoursesManagementService.Models.Domain;
using CoursesManagementService.Models.Views;
using CoursesManagementService.Processors.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDb.Repository.Interfaces;

namespace CoursesManagementService.Processors
{
    public class CourseProcessor : ICourseProcessor
    {
        private readonly IRepository<CourseDomain> _repository;
        private readonly IMapper _mapper;

        public CourseProcessor(IRepository<CourseDomain> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateCourseAsync(Course course)
        {
            var courseDomain = _mapper.Map<CourseDomain>(course);
            var filter = _repository.Filter.Eq(x => x.Name, courseDomain.Name);

            if (string.IsNullOrWhiteSpace(courseDomain.Id))
                await _repository.Collection.InsertOneAsync(courseDomain);
            else
                await _repository.Collection.ReplaceOneAsync(filter, courseDomain, new ReplaceOptions { IsUpsert = true });
        }

        public async Task CreateCoursesAsync(List<Course> courses)
        {
            await _repository.Collection.InsertManyAsync(courses.ConvertAll(x => _mapper.Map<CourseDomain>(x)));
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return (await (await _repository.Collection.FindAsync(_repository.Filter.Empty))
                .ToListAsync())
                .ConvertAll(x => _mapper.Map<Course>(x))
                .ToList();
        }
    }
}
