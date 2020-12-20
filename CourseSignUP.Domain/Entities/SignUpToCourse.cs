namespace CourseSignUp.Domain.Entities
{
    public class SignUpToCourse
    {
        public int SignUPId { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
