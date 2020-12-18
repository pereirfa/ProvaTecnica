using MediatR;

namespace CourseSignUp.Services.Commands.Course
{
    public class GetByIdCourseQuery : IRequest<Domain.Entities.Course>
    {
        public int Id { get; private set; }

        public GetByIdCourseQuery(int id)
        {
            Id = id;
        }
    }
}
