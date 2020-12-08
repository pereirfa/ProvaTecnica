using CourseSignUP.DTO;
using System.Collections.Generic;

namespace CourseSignUP.Interfaces
{
    public interface ICoursesAppService
    {
        IEnumerable<CourseDto> GetCourse();
        bool CreateCourse(CreateCourseDto course);
        bool SignUPCourse(SignUpToCourseDto matricula);
    }
}

