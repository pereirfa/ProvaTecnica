using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Repository;
using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace CourseSignUp.Infra.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _configuration;
        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Student Get(int id)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString = " SELECT StudentId , Email ,StudentName , DateOfBirth " +
                                 " from dbo.Student " +
                                 " WHERE StudentId = @Id ";

            var student = new Student();

            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        student.StudentId = reader.GetInt32(0);
                        student.Email = reader.GetString(1);
                        student.StudentName = reader.GetString(2);
                        student.DateOfBirth = reader.GetDateTime(3);
                    };
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString = " SELECT StudentId , Email ,StudentName , DateOfBirth " +
                                 " from dbo.Student ";

            var students = new List<Student>();

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
                        students.Add(new Student()
                        {
                            StudentId = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            StudentName = reader.GetString(2),
                            DateOfBirth = reader.GetDateTime(3)
                        });
                    };
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return students;
        }

        public bool VerifyStudent(Student student) 
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString = " select StudentId " +
                                 " from dbo.Student " +
                                 " where StudentName = @Name ";

            int qtdstudent = 0;

            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = student.StudentName.Trim();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                      if ( reader.GetValue(0) != DBNull.Value  )
                        qtdstudent = reader.GetInt32(0);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (qtdstudent == 0)
                return false;
            else
                return true;  
        }

        public bool Create(Student student)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString =
              "  INSERT into dbo.Student (  Email ,StudentName ,DateOfBirth ) " +
              "  VALUES ( @Email , @Name ,  @Data ) ";

            if( VerifyStudent(student) ) 
            {
               throw new ArgumentException("Aluno já cadastrado");
            }

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Email", SqlDbType.VarChar, 20).Value = student.Email;
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = student.StudentName;
                    command.Parameters.Add("@Data", SqlDbType.DateTime).Value = student.DateOfBirth;
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

        public bool Delete(int id)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString =
              "  Delete from dbo.Student where StudentId = @Id ";

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
