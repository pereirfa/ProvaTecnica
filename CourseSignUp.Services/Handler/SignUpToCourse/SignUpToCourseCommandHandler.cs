using CourseSignUp.Domain.Repository;
using CourseSignUp.Services.Commands.SignUpToCourse;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignUp.Services.Handler.SignUpToCourse
{
    public class SignUpToCourseCommandHandler : IRequestHandler<CreateSignUpToCourseCommand, bool> ,
                                                IRequestHandler<GetByIdSignUpToCourseQuery, Domain.Entities.SignUpToCourse>
    {
        private readonly ISignUpToCourseRepository _SignUPtoCourseRepository;

        public SignUpToCourseCommandHandler(
            ISignUpToCourseRepository signUPtoCourseRepository)
        {
            _SignUPtoCourseRepository = signUPtoCourseRepository;
        }

        public Task<bool> Handle(CreateSignUpToCourseCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _SignUPtoCourseRepository.Create(request.IdCourse , request.IdStudent)
            );
        }


        public Task<Domain.Entities.SignUpToCourse> Handle(GetByIdSignUpToCourseQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _SignUPtoCourseRepository.Get(request.Id)
            );
        }

    }
}
