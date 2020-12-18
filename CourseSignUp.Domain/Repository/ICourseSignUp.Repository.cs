using CourseSignUp.Domain.Entities;
using System.Collections.Generic;

namespace CourseSignUp.Domain.Repository
{
    public interface ICourseSignUpRepository
    {
        IEnumerable<Course> GetAll();

        Course Get(string id);

        Course Update(Course course);

        Course Create(Course course);

        string Delete(string id);
    }
}
