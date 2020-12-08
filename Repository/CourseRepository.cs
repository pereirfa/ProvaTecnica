using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using CourseSignUP.DTO;
using System.Collections.Generic;

namespace CourseSignUP.Repository
{
    public class CourseRepository 
    {
        private readonly IConfiguration _configuration;
        public CourseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<CourseDto> Consultar()
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            var courses = new List<CourseDto>();

            string queryString =
              " SELECT Id, Capacity, NumberOfStudents " +
              " FROM dbo.COURSE " +
              " ORDER BY Capacity;";

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
                        courses.Add(new CourseDto() { 
                            Id = reader.GetString(0),
                            Capacity = reader.GetInt32(1),
                            NumberOfStudents = reader.GetInt32(2)
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return courses;
        }
    }
}
