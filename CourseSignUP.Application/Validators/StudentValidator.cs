using CourseSignUp.Application.Model;
using FluentValidation;

namespace CourseSignUp.Application.Validators
{
    public class StudentValidator : AbstractValidator<StudentModel>
    {
       public StudentValidator() 
       {
            RuleFor(x => string.IsNullOrWhiteSpace(x.StudentName))
                .Equal(true).WithMessage("Informar o nome do aluno.");
            RuleFor(x => x.StudentName.Length > 50 ).Equal(true).WithMessage("Nome do aluno excedeu tamanho máximo permitido.");
            RuleFor(x => x.Email.Length > 20).Equal(true).WithMessage("Email do aluno excedeu tamanho máximo permitido.");
            RuleFor(x => x.DateOfBirth).Empty().WithMessage("Necessário informar a data de nascimento do aluno.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Necessário informar um e-mail válido.");
        }
    }
}
