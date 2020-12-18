using CourseSignUp.Domain.Repository;
using CourseSignUp.Services.Commands.Student;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignUp.Services.Handler.Student
{
    public class StudentCommandHandler :
        IRequestHandler<CreateStudentCommand, bool >,
        IRequestHandler<GetAllStudentQuery, IEnumerable<Domain.Entities.Student>>,
        IRequestHandler<GetByIdStudentQuery, Domain.Entities.Student>,
        IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentRepository _StudentRepository;

        public StudentCommandHandler(
            IStudentRepository studentRepository)
        {
            _StudentRepository = studentRepository;
        }

        public Task<Domain.Entities.Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _StudentRepository.Create(request.Student)
            );
        }

        public Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _StudentRepository.Delete(request.Id)
            ); ;
        }

        public Task<IEnumerable<Domain.Entities.Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _StudentRepository.GetAll()
            );
        }

        public Task<Domain.Entities.Student> Handle(GetByIdStudentQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _StudentRepository.Get(request.Id)
            );
        }

    }
}
