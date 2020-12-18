using MediatR;

namespace CourseSignUp.Services.Commands.Student
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int Id { get; private set; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
