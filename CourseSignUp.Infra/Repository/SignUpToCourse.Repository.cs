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

        public SignUpToCourse Get(string id)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString = "SELECT CourseId, Email, Name , DateOfBirth  FROM dbo.SignUPToCourse Where CourseId = @Id ";
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
                        signupretorno.CourseId = reader.GetString(0);
                        aluno.Email = reader.GetString(1);
                        aluno.Name = reader.GetString(2);
                        aluno.DateOfBirth = reader.GetDateTime(3);
                        signupretorno.Student = aluno;
     
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
              "  INSERT INTO dbo.SignUPToCourse(CourseId, Email, Name, DateOfBirth) " +
                "VALUES(@CourseId, @Email, @Name, @DateOfBirth )";

            using (SqlConnection connection =
             new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@CourseId", SqlDbType.VarChar, 5).Value = courseSignUpToCourse.CourseId;
                    command.Parameters.Add("@Email", SqlDbType.VarChar, 20).Value = courseSignUpToCourse.Student.Email;
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = courseSignUpToCourse.Student.Name;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime, 10).Value = courseSignUpToCourse.Student.DateOfBirth;
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
