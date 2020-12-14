using CourseSignUp.Domain.Model;
using CourseSignUp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Infra.Repository
{
    public class CourseSignUpRepository : ICourseSignUpRepository
    {
        public CourseSignUpRepository()
        {

        }

        public IEnumerable<CourseModel> GetAll()
        {
            var courses = new List<CourseModel>();
            courses.Add(new CourseModel()
            {
                Id = "SGU",
                Capacity = 99,
                NumberOfStudents = 59
            });

            return courses;
        }

        public CourseModel Get(string id)
        {
            var course = new CourseModel()
            {
                Id = id,
                Capacity = 9,
                NumberOfStudents = 5
            };

            return course;
        }

        public CourseModel Update(CourseModel course)
        {
            course.Id = "SGU";
            course.Capacity = 888;
            course.NumberOfStudents = 235;

            return course;
        }

        public CourseModel Create(CourseModel course)
        {
            course.Capacity = 999;
            return course;
        }

        public string Delete(string id)
        {
            return String.Format("Deletado {0}", id);
        }
    }
}
