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

        #region  public CoursesAppService (IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger_) 
        public CoursesAppService (IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger_) 
        {
            _configuration = configuration;
            _repository = new CourseRepository(_configuration);
        }
        #endregion

        #region  public IEnumerable<CourseDto> GetCourse(string Id) 
        public IEnumerable<CourseDto> GetCourse(string Id) 
        {
           return _repository.Consultar(Id);
        }
        #endregion

        #region  public string CreateCourse(CourseDto course) 
        public string CreateCourse(CourseDto course)
        {
            var curso = new CourseDto();

            curso = _repository.Consultar(course.Id).FirstOrDefault();

            if (curso != null)
                return "Curso já cadastrado!";
            else 
            {
               _repository.Incluir(course);
                return "Curso cadastrado com sucesso!" ; 
            }
          
        }
        #endregion

        #region  public string SignUPCourse(string id) 
        public string SignUPCourse(SignUpToCourseDto matricula)
        {
            var curso = new CourseDto(); 
            
            curso = _repository.Consultar(matricula.CourseId).FirstOrDefault(); 

            if ( curso == null )
                return "Curso inválido!";

            if ( curso.Capacity == curso.NumberOfStudents) 
              return "Curso com capacidade de inscritos lotada!";
            else
            { 
                _repository.Matricular(matricula);
                return  "Aluno cadastrado com sucesso!";
            }
    
        }
        #endregion


    }
}
