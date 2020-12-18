using MediatR;

namespace CourseSignUp.Services.Commands.SignUpToCourse
{
    public class CreateSignUpToCourseCommand : IRequest<Domain.Entities.SignUpToCourse>
    {
        public Domain.Entities.SignUpToCourse SignUpToCourse { private set; get; }

        public CreateSignUpToCourseCommand(Domain.Entities.SignUpToCourse signUpToCourse)
        {
            SignUpToCourse = signUpToCourse;
        }
    }
}
