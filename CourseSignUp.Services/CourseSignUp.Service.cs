using CourseSignUp.Domain.Model;
using CourseSignUp.Domain.Repository;
using CourseSignUp.Services.Interfaces;
using System.Collections.Generic;

namespace CourseSignUp.Services
{
    public class CourseSignUpService : ICourseSignUpService
    {
        private readonly ICourseSignUpRepository _CourseRepository;
        public CourseSignUpService(ICourseSignUpRepository courseRepository)
        {
            _CourseRepository = courseRepository;
        }

        public IEnumerable<CourseModel> GetAll()
        {
            return _CourseRepository.GetAll(); ;
        }

        public CourseModel Get(string id)
        {
            return _CourseRepository.Get(id);
        }

        public CourseModel Update(CourseModel course)
        {
            return _CourseRepository.Update(course);
        }

        public CourseModel Create(CourseModel course)
        {
            return _CourseRepository.Create(course);
        }

        public string Delete(string id)
        {
            return _CourseRepository.Delete(id);
        }
    }
}
