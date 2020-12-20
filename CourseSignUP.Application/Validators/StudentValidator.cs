using CourseSignUp.Application.Model;
using FluentValidation;

namespace CourseSignUp.Application.Validators
{
    public class StudentValidator : AbstractValidator<StudentModel>
    {
       public StudentValidator() 
       {
            RuleFor(x => string.IsNullOrWhiteSpace(x.StudentName))
                .Equal(false).WithMessage("Informar o nome do aluno.");
            RuleFor(x => x.StudentName.Length > 50 ).Equal(false).WithMessage("Nome do aluno excedeu tamanho máximo permitido.");
            RuleFor(x => x.Email.Length > 20).Equal(false).WithMessage("Email do aluno excedeu tamanho máximo permitido.");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Necessário informar a data de nascimento do aluno.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Necessário informar um e-mail válido.");
        }
    }
}
