using CourseSignUp.Application.Model;
using System.Collections.Generic;

namespace CourseSignUp.Application.Model
{
    public class SignUpToCourseModel
    {
       public CourseModel Course { get; set; }

       public IEnumerable<StudentModel> Student { get; set; }
    }
}
