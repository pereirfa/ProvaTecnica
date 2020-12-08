using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseSignUP.Interfaces;
using CourseSignUP.DTO;
using CourseSignUP.Repository;

namespace CourseSignUP.AppServices
{
    public class CoursesAppService : ICoursesAppService 
    {
        private readonly IConfiguration _configuration;
        private Microsoft.Extensions.Logging.ILogger _LoggerFactory;
        CourseRepository _repository;

        public CoursesAppService (IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger_) 
        {
            _configuration = configuration;
            _repository = new CourseRepository(_configuration);
        }

        #region  public IEnumerable<CourseDto> GetCourse(string id) 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<CourseDto> GetCourse() 
        {
           return _repository.Consultar();
        }
        #endregion
    }
}
