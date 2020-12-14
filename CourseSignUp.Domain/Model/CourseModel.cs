namespace CourseSignUp.Domain.Model
{
    public class CourseModel
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }

        public bool CheckCapacity(string id)
        {
            if ( NumberOfStudents >= Capacity )
                return false;
            else
                return true;
        }
    }
}
