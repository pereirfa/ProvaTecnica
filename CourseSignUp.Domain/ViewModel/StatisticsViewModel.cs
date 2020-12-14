using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.ViewModel
{
    public class StatisticsViewModel
    {
        public string CourseId { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int AvgAge { get; set; }
    }
}
