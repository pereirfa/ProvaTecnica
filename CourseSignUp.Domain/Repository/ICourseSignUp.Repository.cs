using CourseSignUp.Domain.Model;
using System.Collections.Generic;

namespace CourseSignUp.Domain.Repository
{
    public interface ICourseSignUpRepository
    {
        IEnumerable<CourseModel> GetAll();

        CourseModel Get(string id);

        CourseModel Update(CourseModel course);

        CourseModel Create(CourseModel course);

        string Delete(string id);
    }
}
