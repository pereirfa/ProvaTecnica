using MediatR;
using System.Collections.Generic;

namespace CourseSignUp.Services.Commands.Student
{
    public class GetAllStudentQuery : IRequest<IEnumerable<Domain.Entities.Student>>
    {
    }
}
