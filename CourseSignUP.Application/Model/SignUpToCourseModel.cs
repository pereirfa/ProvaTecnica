using CourseSignUp.Application.Model;

namespace CourseSignUp.Application.Model
{
    public class SignUpToCourseModel
    {
        public int SignUPId { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public CourseModel Course { get; set; }
        public StudentModel Student { get; set; }
    }
}
