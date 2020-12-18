using MediatR;

namespace CourseSignUp.Services.Commands.Course
{
    public class CreateCourseCommand : IRequest<bool>
    {
        public Domain.Entities.Course Course { private set; get; }

        public CreateCourseCommand(Domain.Entities.Course course)
        {
            Course = course;
        }
    }
}
