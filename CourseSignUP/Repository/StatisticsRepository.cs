using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using CourseSignUP.DTO;
using System.Collections.Generic;
using System.Data;

namespace CourseSignUP.Repository
{
    public class StatisticsRepository
    {
        private readonly IConfiguration _configuration;
        public StatisticsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<StatisticsDto> Consultar()
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            var statistics = new List<StatisticsDto>();

            string queryString =
            " SELECT CourseId , " +
            "  MIN(DATEDIFF(hour, DateOfBirth, getdate()) / 8766) as MinAge , " +
            "  Max(DATEDIFF(hour, DateOfBirth, getdate()) / 8766) as MaxAge , " +
            "  AVG(DATEDIFF(hour, DateOfBirth, getdate()) / 8766) as AvgAge " +
            "  FROM dbo.SignUPToCourse " +
            "  GROUP BY CourseId ; " ; 

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        statistics.Add(new StatisticsDto()
                        {
                            CourseId = reader.GetString(0),
                            MinAge = reader.GetInt32(1),
                            MaxAge = reader.GetInt32(2) ,
                            AvgAge = reader.GetInt32(3)
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return statistics;
        }


    }
}
