using CourseSignUP.DTO;
using System.Collections.Generic;

namespace CourseSignUP.Interfaces
{
    public interface IStatisticsAppService
    {
        IEnumerable<StatisticsDto> GetStatistics();
    }
}
