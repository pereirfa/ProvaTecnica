using MediatR;

namespace CourseSignUp.Services.Commands.Course
{
    public class CreateCourseCommand : IRequest<Domain.Entities.Course>
    {
        public Domain.Entities.Course Course { private set; get; }

        public CreateCourseCommand(Domain.Entities.Course cource)
        {
            Course = cource;
        }
    }
}
