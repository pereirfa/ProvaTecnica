using CourseSignUp.Domain.Entities;
using System.Collections.Generic;

namespace CourseSignUp.Domain.Repository
{
    public interface IStatisticsRepository
    {
        IEnumerable<Statistics> GetAll();

        Statistics Get(string id);
    }
}
