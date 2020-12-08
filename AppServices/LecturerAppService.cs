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
    public class LecturerAppService : ILecturerAppService
    {
        private readonly IConfiguration _configuration;
        private Microsoft.Extensions.Logging.ILogger _LoggerFactory;
        LecturerRepository _repository;

        public LecturerAppService(IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger_)
        {
            _configuration = configuration;
            _repository = new LecturerRepository(_configuration);
        }

        #region  public bool CreateLecturer(CreateLecturerDto lecturer  ) 
        public bool CreateLecturer(CreateLecturerDto lecturer)
        {
            return _repository.Incluir(lecturer);
        }
        #endregion

    }
}
