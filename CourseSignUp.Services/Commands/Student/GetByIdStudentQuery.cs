using MediatR;

namespace CourseSignUp.Services.Commands.Student
{
    public class GetByIdStudentQuery : IRequest<Domain.Entities.Student>
    {
        public int Id { get; private set; }

        public GetByIdStudentQuery(int id)
        {
            Id = id;
        }
    }
}
