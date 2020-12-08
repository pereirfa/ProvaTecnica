using CourseSignUP.Interfaces;
using CourseSignUP.DTO;
using CourseSignUP.Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CourseSignUP.AppServices
{
    public class StatisticsAppService : IStatisticsAppService
    {
        private readonly IConfiguration _configuration;
        private Microsoft.Extensions.Logging.ILogger _LoggerFactory;
        StatisticsRepository _repository;

        public StatisticsAppService(IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger_)
        {
            _configuration = configuration;
            _repository = new StatisticsRepository(_configuration);
        }

        #region  public IEnumerable<StatisticsDto> GetStatistics() 
        public IEnumerable<StatisticsDto> GetStatistics()
        {
            return _repository.Consultar();
        }
        #endregion


    }
}
