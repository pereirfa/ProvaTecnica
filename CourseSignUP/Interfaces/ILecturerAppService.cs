using CourseSignUP.DTO;
using System.Collections.Generic;

namespace CourseSignUP.Interfaces
{
    public interface ILecturerAppService
    {
        bool CreateLecturer(CreateLecturerDto lecturer);
    }
}
