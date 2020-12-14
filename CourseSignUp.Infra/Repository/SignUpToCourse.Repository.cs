using CourseSignUp.Domain.Model;
using CourseSignUp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Infra.Repository
{
    public class SignUpToCourseRepository : ISignUpToCourseRepository
    {
        public SignUpToCourseRepository()
        {
          
        }

        public SignUpToCourseModel Create(SignUpToCourseModel signUpcourse)
        {
            signUpcourse.CourseId = "SGU";
            signUpcourse.Student.Name = "Joao da Silva";
            signUpcourse.Student.DateOfBirth = new DateTime(1976, 04, 01, 0, 0, 0);
            signUpcourse.Student.Email = "email@teste.com.br";
            return signUpcourse;
        }


    }
}
