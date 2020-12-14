using CourseSignUp.Domain.Model;
using CourseSignUp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Infra.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        public StatisticsRepository()
        {

        }

        public IEnumerable<StatisticsModel> GetAll()
        {
            var statistics = new List<StatisticsModel>();
            statistics.Add(new StatisticsModel()
            {
                CourseId = "SGU",
                MaxAge = 70,
                MinAge = 20,
                AvgAge = 35
            });

            return statistics;
        }

        public StatisticsModel Get(string id)
        {
            var statistics = new StatisticsModel()
            {
                CourseId = id,
                MaxAge = 50,
                MinAge = 20,
                AvgAge = 25
            };

            return statistics;
        }

    }
}
