using CourseSignUp.Domain.Repository;
using CourseSignUp.Services.Commands.Course;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignUp.Services.Handler.Course
{
    public class CourseCommandHandler : IRequestHandler<CreateCourseCommand, bool>,
                                        IRequestHandler<UpdateCourseCommand, Domain.Entities.Course>,
                                        IRequestHandler<GetByIdCourseQuery, Domain.Entities.Course>,
                                        IRequestHandler<GetAllCourseQuery, IEnumerable<Domain.Entities.Course>>,
                                        IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly ICourseSignUpRepository _CourseRepository;

        public CourseCommandHandler(ICourseSignUpRepository courseRepository)
        {
            _CourseRepository = courseRepository;
        }

        public Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _CourseRepository.Create(request.Course)
            );
        }

        public Task<Domain.Entities.Course> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _CourseRepository.Update(request.Course)
            );
        }

        public Task<Domain.Entities.Course> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _CourseRepository.Get(request.Id) 
            );
        }

        public Task<IEnumerable<Domain.Entities.Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _CourseRepository.GetAll()
            );
        }

        public Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _CourseRepository.Delete(request.Id)
            ); ;
        }
    }
}
