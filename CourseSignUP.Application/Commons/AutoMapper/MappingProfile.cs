using AutoMapper;
using CourseSignUp.Application.Model;
using CourseSignUp.Domain.Entities;

namespace CourseSignUp.Application.Utils.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseModel, Course>();
            CreateMap<Course, CourseModel>();

            CreateMap<SignUpToCourseModel, SignUpToCourse>()
                .ForMember(p => p.Student, opts => opts.MapFrom(source => source.Student));
                
            CreateMap<SignUpToCourse, SignUpToCourseModel>()
                .ForMember(p => p.Student, map => map.MapFrom(src => new Student { Name = src.Student.Name, Email = src.Student.Email, DateOfBirth = src.Student.DateOfBirth }));

            CreateMap<StatisticsModel, Statistics>();
            CreateMap<Statistics, StatisticsModel>();

        }
    }
}
