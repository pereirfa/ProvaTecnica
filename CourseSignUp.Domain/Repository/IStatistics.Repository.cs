using CourseSignUp.Domain.Model;
using System.Collections.Generic;

namespace CourseSignUp.Domain.Repository
{
    public interface IStatisticsRepository
    {
        IEnumerable<StatisticsModel> GetAll();

        StatisticsModel Get(string id);
    }
}
