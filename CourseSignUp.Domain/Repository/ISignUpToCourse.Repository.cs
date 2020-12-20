using CourseSignUp.Domain.Entities;

namespace CourseSignUp.Domain.Repository
{
    public interface ISignUpToCourseRepository
    {
        bool Create(int IdCourse , int IdStudent);

        SignUpToCourse Get(int id);
    }
}
