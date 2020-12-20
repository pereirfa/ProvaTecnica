using CourseSignUp.Domain.Entities;
using System.Collections.Generic;

namespace CourseSignUp.Domain.Repository
{
    public interface ICourseSignUpRepository
    {
        IEnumerable<Course> GetAll();

        Course Get(int id);

        Course Update(Course course);

        bool Create(Course course);

        bool Delete(int id);

        bool UpdateNumberStudents(int idCourse);

    }
}
