using CourseSignUp.Application.Model;

namespace CourseSignUp.Application.Model
{
    public class SignUpToCourseModel
    {
        public CourseModel Course { get; set; }
        public StudentModel Student { get; set; }
    }
}
