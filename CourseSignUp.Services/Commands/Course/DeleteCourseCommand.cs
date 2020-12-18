using MediatR;

namespace CourseSignUp.Services.Commands.Course
{
    public class DeleteCourseCommand : IRequest<bool>
    {
        public int Id { get; private set; }

        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
