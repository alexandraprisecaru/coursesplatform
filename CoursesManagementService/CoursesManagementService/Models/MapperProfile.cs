using AutoMapper;
using CoursesManagementService.Models.Domain;
using CoursesManagementService.Models.Views;

namespace CoursesManagementService.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CourseDomain, Course>();
            CreateMap<Course, CourseDomain>();

            CreateMap<UserAssignmentDomain, UserAssignment>();
            CreateMap<UserAssignment, UserAssignmentDomain>();
        }
    }
}
