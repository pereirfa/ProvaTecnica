using System.Collections.Generic;

namespace CourseSignUp.Domain.Entities
{
    public class SignUpToCourse
    {
        public int SignUPId { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public Course Course { get; set; }
        public IEnumerable<Student> Student { get; set; }
    }
}
