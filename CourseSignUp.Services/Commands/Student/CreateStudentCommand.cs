using MediatR;

namespace CourseSignUp.Services.Commands.Student
{
    public class CreateStudentCommand : IRequest<bool>
    {
        public Domain.Entities.Student Student { private set; get; }

        public CreateStudentCommand(Domain.Entities.Student student)
        {
            Student = student;
        }

    }
}
