using CourseSignUp.Application.Model;

namespace CourseSignUp.Application.Model
{
    public class SignUpToCourseModel
    {
        public string CourseId { get; set; }
        public StudentModel Student { get; set; }
    }
}
