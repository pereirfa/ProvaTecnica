using MediatR;

namespace CourseSignUp.Services.Commands.SignUpToCourse
{
    public class GetByIdSignUpToCourseQuery : IRequest<Domain.Entities.SignUpToCourse>
    {
        public int Id { get; private set; }

        public GetByIdSignUpToCourseQuery(int id)
        {
            Id = id;
        }
    }
}
