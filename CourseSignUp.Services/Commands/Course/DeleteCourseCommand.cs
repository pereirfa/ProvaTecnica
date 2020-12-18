using MediatR;

namespace CourseSignUp.Services.Commands.Course
{
    public class DeleteCourseCommand : IRequest<string>
    {
        public string Id { get; private set; }

        public DeleteCourseCommand(string id)
        {
            Id = id;
        }
    }
}
