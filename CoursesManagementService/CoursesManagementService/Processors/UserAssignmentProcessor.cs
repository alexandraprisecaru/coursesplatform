using CoursesManagementService.Models;
using CoursesManagementService.Processors.Interfaces;
using MongoDB.Driver;
using MongoDb.Repository.Interfaces;

namespace CoursesManagementService.Processors
{
    public class CourseAssignmentsProcessor : ICourseAssignmentsProcessor
    {

        private readonly IRepository<UserAssignment> _repository;

        public CourseAssignmentsProcessor(IRepository<UserAssignment> repository)
        {
            _repository = repository;
        }

        public async Task AssignCoursesAsync(UserAssignment userAssignment)
        {
            var filter = _repository.Filter.Eq(x => x.Id, userAssignment.Id);

            if (string.IsNullOrWhiteSpace(userAssignment.Id))
                await _repository.Collection.InsertOneAsync(userAssignment);
            else
                await _repository.Collection.ReplaceOneAsync(filter, userAssignment, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<List<UserAssignment>> GetUserAssignmentsAsync(string userId)
        {
            var filter = _repository.Filter.Eq(x => x.Id, userId);

            return await (await _repository.Collection.FindAsync(filter)).ToListAsync();
        }
    }
}
