using System;

namespace CourseSignUp.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Email { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
