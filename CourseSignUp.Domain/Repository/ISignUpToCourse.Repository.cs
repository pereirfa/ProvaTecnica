using CourseSignUp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Repository
{
    public interface ISignUpToCourseRepository
    {
        SignUpToCourseModel Create(SignUpToCourseModel courseSignUpToCourse);
    }
}
