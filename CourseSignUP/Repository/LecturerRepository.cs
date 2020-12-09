using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using CourseSignUP.DTO;
using System.Collections.Generic;
using System.Data;


namespace CourseSignUP.Repository
{
    public class LecturerRepository
    {
        private readonly IConfiguration _configuration;
        public LecturerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Incluir(CreateLecturerDto conf)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString =
              "  INSERT INTO dbo.Lecturer(Name) " + 
              "  VALUES(@Name) ";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = conf.Name;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return true;
        }


    }
}
