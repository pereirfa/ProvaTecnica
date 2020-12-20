using System.Collections.Generic;

namespace CourseSignUp.Domain.Entities
{
    public class SignUpToCourse
    {
        public Course Course { get; set; }

        public IEnumerable<Student> Student { get; set; }

    }
}
