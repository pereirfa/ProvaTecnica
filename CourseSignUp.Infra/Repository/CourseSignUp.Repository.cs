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
            string queryString = "SELECT CourseId , CourseName, Capacity, NumberOfStudents FROM dbo.COURSE ";
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
                            CourseId = reader.GetInt32(0),
                            CourseName = reader.GetString(1),
                            Capacity = reader.GetInt32(2),
                            NumberOfStudents = reader.GetInt32(3)
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

        public Course Get(int id)
        {
          string connectionString = _configuration.GetConnectionString("ConnectionCourse");
          string queryString = "SELECT CourseId, CourseName , Capacity, NumberOfStudents FROM dbo.COURSE Where CourseId = @Id ";
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
                        course.CourseId = reader.GetInt32(0);
                        course.CourseName = reader.GetString(1);
                        course.Capacity = reader.GetInt32(2);
                        course.NumberOfStudents = reader.GetInt32(3);
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
            string queryString = "UPDATE dbo.COURSE SET CourseName = @CourseName , Capacity = @Capacity , NumberOfStudents = @NumberOfStudents Where CourseId = @Id ";
            var returncourse = new Course();

            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = course.CourseId;
                    command.Parameters.Add("@CourseName", SqlDbType.VarChar, 50).Value = course.CourseName;
                    command.Parameters.Add("@Capacity", SqlDbType.Int).Value = course.Capacity;
                    command.Parameters.Add("@NumberOfStudents", SqlDbType.Int).Value = course.NumberOfStudents;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    returncourse = Get(course.CourseId);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return returncourse;
        }

        public bool Create(Course course)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString =
              "  INSERT INTO dbo.Course( CourseName, NumberOfStudents, Capacity) " +
                 "VALUES ( @CourseName, @NumberOfStudents, @Capacity) ";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@CourseName", SqlDbType.VarChar, 50).Value = course.CourseName;
                    command.Parameters.Add("@NumberOfStudents", SqlDbType.Int).Value = course.NumberOfStudents;
                    command.Parameters.Add("@Capacity", SqlDbType.Int).Value = course.Capacity;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception )
                {
                    throw;
                }
            }

            return true;

        }


        public bool Delete(int id)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString =
              "  Delete from dbo.Course where CourseId = @Id ";

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return true;
        }

      
    }
}
