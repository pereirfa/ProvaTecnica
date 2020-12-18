using CourseSignUp.Application.Model;
using FluentValidation;
using System;

namespace CourseSignUp.Application.Validators
{
    public class SignUpToCourseValidator : AbstractValidator<SignUpToCourseModel>
    {
        public SignUpToCourseValidator()
        {
            RuleFor(x => x.Course.CourseId == 0 )
                .Equal(false).WithMessage("Necessário informar o ID do curso.");
          
        }
    }
}
