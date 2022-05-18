using AutoMapper;
using CoursesManagementService.Models.Domain;
using CoursesManagementService.Models.Views;

namespace CoursesManagementService.Models
{
    /// <summary>
    /// Mapping configuration
    /// </summary>
    public class MapperProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MapperProfile()
        {
            CreateMap<CourseDomain, Course>();
            CreateMap<Course, CourseDomain>();

            CreateMap<UserAssignmentDomain, UserCourseAssignment>();
            CreateMap<UserCourseAssignment, UserAssignmentDomain>();
        }
    }
}
