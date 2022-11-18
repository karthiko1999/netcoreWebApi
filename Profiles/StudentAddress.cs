using AutoMapper;

namespace StudentManagement.Profiles
{
    public class StudentAddressProfile:Profile
    {
        public StudentAddressProfile()
        {
            CreateMap<Models.Domain.StudentAddress , Models.DTOs.StudentAddress>().ForMember(dest => dest.IdOfStudentAddress ,options=> options.MapFrom(src=> src.StudentAddressId)).ReverseMap();

             CreateMap<Models.Domain.StudentAddress,   Models.DTOs.AddStudentAddressRequest>().ReverseMap();
            CreateMap<Models.Domain.StudentAddress,   Models.DTOs.UpdateStudentAddressRequest>().ReverseMap();
        }
    }
}