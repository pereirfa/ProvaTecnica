namespace CourseSignUp.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }

        public bool CheckCapacity()
        {
            if ( NumberOfStudents >= Capacity )
                return false;
            else
                return true;
        }

    }
}
