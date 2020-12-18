using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Repository;
using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CourseSignUp.Infra.Repository
{
    public class SignUpToCourseRepository : ISignUpToCourseRepository
    {
        private readonly IConfiguration _configuration;
        public SignUpToCourseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SignUpToCourse Get(int id)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString = " Select C.CourseName , S.StudentName , S.Email , S.DateOfBirth " +
                                 " from dbo.SignUPToCourse SU" +
                                 " INNER JOIN dbo.Student S on SU.StudentId = S.StudentId " +
                                 " INNER JOIN dbo.Course C on SU.CourseId = C.CourseId " +
                                 " WHERE SU.CourseId = @Id ";

            var signupretorno = new SignUpToCourse();
            var aluno = new Student();



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
                        /*signupretorno. = reader.GetString(0);
                        aluno.Email = reader.GetString(1);
                        aluno.Name = reader.GetString(2);
                        aluno.DateOfBirth = reader.GetDateTime(3);
                        signupretorno.Student = aluno;
                        */
                    };
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return signupretorno;
        }

        public SignUpToCourse Create(SignUpToCourse courseSignUpToCourse)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            var signupretorno = new SignUpToCourse();
            string queryString =
              "  INSERT INTO dbo.SignUPToCourse(CourseId, StudentId) " +
                "VALUES(@CourseId, @StudentId)";

            using (SqlConnection connection =
             new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@CourseId", SqlDbType.VarChar, 5).Value = courseSignUpToCourse.CourseId;
                    command.Parameters.Add("@StudentId", SqlDbType.VarChar, 20).Value = courseSignUpToCourse.StudentId;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    signupretorno = Get(courseSignUpToCourse.CourseId);
                }
                catch (Exception )
                {
                    throw;
                }
            }
            return signupretorno; 
        }
    }
}
