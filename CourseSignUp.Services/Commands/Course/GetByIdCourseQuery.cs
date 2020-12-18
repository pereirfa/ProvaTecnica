using MediatR;

namespace CourseSignUp.Services.Commands.Course
{
    public class GetByIdCourseQuery : IRequest<Domain.Entities.Course>
    {
        public string Id { get; private set; }

        public GetByIdCourseQuery(string id)
        {
            Id = id;
        }
    }
}
