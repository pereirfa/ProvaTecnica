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

            CreateMap<SignUpToCourseModel , SignUpToCourse>();
            CreateMap<SignUpToCourse, SignUpToCourseModel>();

            CreateMap<StatisticsModel, Statistics>();
            CreateMap<Statistics, StatisticsModel>();

            CreateMap<StudentModel, Student>();
            CreateMap<Student, StudentModel>();
        }
    }
}
