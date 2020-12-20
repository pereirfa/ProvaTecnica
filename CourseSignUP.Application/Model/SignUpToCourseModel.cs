using CourseSignUp.Application.Model;
using System.Collections.Generic;

namespace CourseSignUp.Application.Model
{
    public class SignUpToCourseModel
    {
        public int SignUPId { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public CourseModel Course { get; set; }
        public IEnumerable<StudentModel> Student { get; set; }
    }
}
