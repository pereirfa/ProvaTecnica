using CourseSignUP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CourseSignUP.Interfaces
{
    public interface ICoursesAppService
    {
        IEnumerable<CourseDto> GetCourse();
    }
}

