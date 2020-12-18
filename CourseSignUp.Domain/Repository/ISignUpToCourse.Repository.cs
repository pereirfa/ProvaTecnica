using CourseSignUp.Domain.Entities;

namespace CourseSignUp.Domain.Repository
{
    public interface ISignUpToCourseRepository
    {
        SignUpToCourse Create(SignUpToCourse courseSignUpToCourse);

        SignUpToCourse Get(int id);
    }
}
