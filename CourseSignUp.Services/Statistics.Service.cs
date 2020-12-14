using CourseSignUp.Domain.Model;
using CourseSignUp.Domain.Repository;
using CourseSignUp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CourseSignUp.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _StatisticsRepository;
        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _StatisticsRepository = statisticsRepository;
        }

        public IEnumerable<StatisticsModel> GetAll()
        {
            return _StatisticsRepository.GetAll(); ;
        }

        public StatisticsModel Get(string id)
        {
            return _StatisticsRepository.Get(id);
        }

    }
}
