using AutoMapper;
using StudentPortal.Web.Models.DTO;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, AddStudentDTO>().ReverseMap();
            CreateMap<Student, UpdateStudentDTO>().ReverseMap();
        }
    }
}
