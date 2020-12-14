using CourseSignUp.Domain.Model;
using CourseSignUp.Domain.Repository;
using CourseSignUp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CourseSignUp.Services
{
    public class SignUpToCourseService : ISignUpToCourseService
    {
        private readonly ISignUpToCourseRepository _SignUPtoCourseRepository;
        public SignUpToCourseService(ISignUpToCourseRepository signUpToCourseRepository)
        {
            _SignUPtoCourseRepository = signUpToCourseRepository;
        }

        public SignUpToCourseModel Create(SignUpToCourseModel courseSignUP)
        {
            return _SignUPtoCourseRepository.Create(courseSignUP);
        }

    }
}
