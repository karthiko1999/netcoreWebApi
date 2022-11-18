using AutoMapper;

namespace StudentManagement.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Models.Domain.Student,Models.DTOs.Student>().ForMember(dest=>dest.IdOfStudent,options=>options.MapFrom(src=> src.StudentID)).ReverseMap();
            CreateMap<Models.Domain.Student,Models.DTOs.AddStudentRequest>().ReverseMap();
            CreateMap<Models.Domain.Student,Models.DTOs.UpdateStudentRequest>().ReverseMap();
        }
    }
    
}