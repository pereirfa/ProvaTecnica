using CourseSignUp.Domain.Entities;

namespace CourseSignUp.Domain.Repository
{
    public interface ISignUpToCourseRepository
    {
        bool Create(SignUpToCourse courseSignUpToCourse);

        SignUpToCourse Get(int id);
    }
}
