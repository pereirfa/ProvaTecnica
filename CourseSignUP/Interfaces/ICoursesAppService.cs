using CourseSignUP.DTO;
using System.Collections.Generic;

namespace CourseSignUP.Interfaces
{
    public interface ICoursesAppService
    {
        IEnumerable<CourseDto> GetCourse(string Id);
        string CreateCourse(CourseDto course);
        string SignUPCourse(SignUpToCourseDto matricula);
    }
}

