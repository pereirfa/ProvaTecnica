using CourseSignUp.Domain.Entities;
using System.Collections.Generic;


namespace CourseSignUp.Domain.Repository
{
    public interface IStudentRepository
    {
        Student Get(int id);

        IEnumerable<Student> GetAll();

        bool Create(Student student);

        bool Delete(int id);

    }
}
