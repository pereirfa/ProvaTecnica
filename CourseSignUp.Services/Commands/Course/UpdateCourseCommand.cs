using MediatR;

namespace CourseSignUp.Services.Commands.Course
{
    public class UpdateCourseCommand : IRequest<Domain.Entities.Course>
    {
        public Domain.Entities.Course Course { private set; get; }

        public UpdateCourseCommand(Domain.Entities.Course course)
        {
            Course = course;
        }
    }
}
