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
                .ForMember(p => p.CourseId, opts => opts.MapFrom(source => source.Course != null ? source.Course.CourseId : 0))
                .ForMember(p => p.StudentId, opts => opts.MapFrom(source => source.Student != null ? source.Student.StudentId : 0));

            CreateMap<SignUpToCourse, SignUpToCourseModel>()
                .ForMember(p => p.Course, map => map.MapFrom(src => new Course { CourseId = src.CourseId }))
                .ForMember(p => p.Student, map => map.MapFrom(src => new Student { StudentId = src.StudentId }));

            CreateMap<StatisticsModel, Statistics>();
            CreateMap<Statistics, StatisticsModel>();

            CreateMap<StudentModel, Student>();
            CreateMap<Student, StudentModel>();


        }
    }
}
