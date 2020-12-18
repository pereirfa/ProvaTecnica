using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Repository;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CourseSignUp.Infra.Repository
{
    public class CourseSignUpRepository : ICourseSignUpRepository
    {

        private readonly IConfiguration _configuration;
        public CourseSignUpRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IEnumerable<Course> GetAll()
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString = "SELECT Id, Capacity, NumberOfStudents FROM dbo.COURSE ";
            var courses = new List<Course>();

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
                        courses.Add(new Course()
                        {
                            Id = reader.GetString(0),
                            Capacity = reader.GetInt32(1),
                            NumberOfStudents = reader.GetInt32(2)
                        });
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

            } 
            return courses;
        }

        public Course Get(string id)
        {
          string connectionString = _configuration.GetConnectionString("ConnectionCourse");
          string queryString = "SELECT Id, Capacity, NumberOfStudents FROM dbo.COURSE Where Id = @Id ";
          var course = new Course();

            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Id", SqlDbType.VarChar, 5).Value = id ;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        course.Id = reader.GetString(0);
                        course.Capacity = reader.GetInt32(1);
                         course.NumberOfStudents = reader.GetInt32(2);
                    };
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return course;
        }

        public Course Update(Course course)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString = "UPDATE dbo.COURSE SET Capacity = @Capacity , NumberOfStudents = @NumberOfStudents Where Id = @Id ";
            var returncourse = new Course();

            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Id", SqlDbType.VarChar, 5).Value = course.Id;
                    command.Parameters.Add("@Capacity", SqlDbType.Int).Value = course.Capacity;
                    command.Parameters.Add("@NumberOfStudents", SqlDbType.Int).Value = course.NumberOfStudents;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    returncourse = Get(course.Id);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return returncourse;
        }

        public Course Create(Course course)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString =
              "  INSERT INTO dbo.Course(Id, NumberOfStudents, Capacity) " +
                 "VALUES (@Id, @NumberOfStudents, @Capacity) ";

            var returncourse = new Course();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Id", SqlDbType.VarChar, 5).Value = course.Id;
                    command.Parameters.Add("@NumberOfStudents", SqlDbType.VarChar, 50).Value = course.NumberOfStudents;
                    command.Parameters.Add("@Capacity", SqlDbType.Int, 5).Value = course.Capacity;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    returncourse = Get(course.Id);
                }
                catch (Exception )
                {
                    throw;
                }
            }

            return returncourse;

        }

        public string Delete(string id)
        {
            var courses = new List<Course>();
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString =
              "  Delete from dbo.Course where Id = @Id ";

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Id", SqlDbType.VarChar, 5).Value = id;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception )
                {
                    throw;
                }
            }

            return String.Format("Registro deletado com sucesso.{0}", id);
        }
    }
}
