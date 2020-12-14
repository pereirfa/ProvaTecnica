using CourseSignUp.Domain.Model;
using System.Collections.Generic;

namespace CourseSignUp.Services.Interfaces
{
    public interface IStatisticsService
    {
        IEnumerable<StatisticsModel> GetAll();

        StatisticsModel Get(string id);
    }
}
