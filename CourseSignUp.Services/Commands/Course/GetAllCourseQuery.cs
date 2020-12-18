using MediatR;
using System.Collections.Generic;

namespace CourseSignUp.Services.Commands.Course
{
    public class GetAllCourseQuery : IRequest<IEnumerable<Domain.Entities.Course>>
    {
    }
}
