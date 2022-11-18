using AutoMapper;

namespace StudentManagement.Profiles
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<Models.Domain.Grade, Models.DTOs.Grade>().ForMember(dest=>dest.IdOfGrade,options=>options.MapFrom(src=> src.GradeId)).ReverseMap();
            CreateMap<Models.Domain.Grade,Models.DTOs.AddGradeRequest>().ReverseMap();
            CreateMap<Models.Domain.Grade,Models.DTOs.UpdateGradeRequest>().ReverseMap();
        }
    }
}