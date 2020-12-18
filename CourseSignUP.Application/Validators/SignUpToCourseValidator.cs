using CourseSignUp.Application.Model;
using FluentValidation;
using System;

namespace CourseSignUp.Application.Validators
{
    public class SignUpToCourseValidator : AbstractValidator<SignUpToCourseModel>
    {
        public SignUpToCourseValidator()
        {
            RuleFor(x => string.IsNullOrWhiteSpace(x.CourseId))
                .Equal(false).WithMessage("Necessário informar o ID do curso.");
            RuleFor(x => string.IsNullOrWhiteSpace(x.Student.Name))
                .Equal(false).WithMessage("Informar o nome do aluno.");
            RuleFor(x => x.Student.DateOfBirth == DateTime.MinValue)
                .Equal(false).WithMessage("Necessário informar a data de nascimento do aluno.");
            RuleFor(x => x.Student.Email)
                .EmailAddress().WithMessage("Necessário informar um e-mail válido.");
        }
    }
}
