using CourseSignUp.Application.Model;
using FluentValidation;

namespace CourseSignUp.Application.Validators
{
    public class CourseValidator : AbstractValidator<CourseModel>
    {
        public CourseValidator()
        {
            RuleFor(x => x.CourseId == 0 )
                .Equal(false).WithMessage("Necessário informar o ID do curso.");
            RuleFor(x => x.Capacity <= 0 || x.Capacity > 40)
                .Equal(false).WithMessage("Capacidade do curso inválida, valores permitidos entre 1 e 40.");
            RuleFor(x => x.NumberOfStudents <= 0)
                .Equal(false).WithMessage("Necessário informar ao menos um estudante.");
        }
    }
}
