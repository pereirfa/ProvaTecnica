using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Repository;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CourseSignUp.Infra.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly IConfiguration _configuration;
        public StatisticsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Statistics> GetAll()
        {
            var statisticresult = new List<Statistics>();
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");

            string queryString =
           " SELECT CourseId , " +
           "  MIN(DATEDIFF(hour, DateOfBirth, getdate()) / 8766) as MinAge , " +
           "  Max(DATEDIFF(hour, DateOfBirth, getdate()) / 8766) as MaxAge , " +
           "  AVG(DATEDIFF(hour, DateOfBirth, getdate()) / 8766) as AvgAge " +
           "  FROM dbo.SignUPToCourse " +
           "  GROUP BY CourseId ; ";

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
                        statisticresult.Add(new Statistics()
                        {
                            CourseId = reader.GetString(0),
                            MinAge = reader.GetInt32(1),
                            MaxAge = reader.GetInt32(2),
                            AvgAge = reader.GetInt32(3)
                        });
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return statisticresult;
        }

        public Statistics Get(string id)
        {
            var statisticresult = new Statistics();
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");

            string queryString =
           " SELECT CourseId , " +
           "  MIN(DATEDIFF(hour, DateOfBirth, getdate()) / 8766) as MinAge , " +
           "  Max(DATEDIFF(hour, DateOfBirth, getdate()) / 8766) as MaxAge , " +
           "  AVG(DATEDIFF(hour, DateOfBirth, getdate()) / 8766) as AvgAge " +
           "  FROM dbo.SignUPToCourse " +
           "  Where CourseId = @Id " +
           "  GROUP BY CourseId ; ";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Id", SqlDbType.VarChar, 5).Value = id;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        statisticresult.CourseId = reader.GetString(0);
                        statisticresult.MinAge = reader.GetInt32(1);
                        statisticresult.MaxAge = reader.GetInt32(2);
                        statisticresult.AvgAge = reader.GetInt32(3);
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return statisticresult;
        }

    }
}
