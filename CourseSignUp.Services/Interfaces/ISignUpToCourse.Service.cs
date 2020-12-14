using CourseSignUp.Domain.Model;
using System.Collections.Generic;

namespace CourseSignUp.Services.Interfaces
{
    public interface ISignUpToCourseService
    {
      SignUpToCourseModel Create(SignUpToCourseModel courseSignUP);

    }
}
