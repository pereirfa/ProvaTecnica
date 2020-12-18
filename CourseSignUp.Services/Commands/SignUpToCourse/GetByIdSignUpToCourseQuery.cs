using MediatR;

namespace CourseSignUp.Services.Commands.SignUpToCourse
{
    public class GetByIdSignUpToCourseQuery : IRequest<Domain.Entities.SignUpToCourse>
    {
        public string Id { get; private set; }

        public GetByIdSignUpToCourseQuery(string id)
        {
            Id = id;
        }
    }
}
