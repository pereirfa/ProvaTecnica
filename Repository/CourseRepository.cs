﻿using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using CourseSignUP.DTO;
using System.Collections.Generic;
using System.Data;

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


        public bool Incluir(CreateCourseDto curso)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString =
              "  INSERT INTO dbo.Lecture(LecturerId, Name, Capacity) " +
                 "VALUES (@LectureId, @Name, @Capacity) ";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@LectureId", SqlDbType.VarChar, 5).Value = curso.LecturerId ;
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = curso.Name;
                    command.Parameters.Add("@Capacity", SqlDbType.Int, 5).Value = curso.Capacity;
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


        public bool Matricular(SignUpToCourseDto matricula)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString =
              "  INSERT INTO dbo.SignUPToCourse(CourseId, Email, Name, DateOfBirth) " +
                "VALUES(@CourseId, @Email, @Name, @DateOfBirth )" ;

            //Atualização da quantidade de alunos por curso
            string queryAtuString =
                "  Update dbo.Course " +
                "    set NumberOfStudents = (select NumberOfStudents + 1 from Course where ID = @CourseId ) " +
                "    where ID = @CourseId "; 

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@CourseId", SqlDbType.VarChar, 5).Value = matricula.CourseId;
                    command.Parameters.Add("@Email", SqlDbType.VarChar, 20).Value = matricula.Student.Email;
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = matricula.Student.Name;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime, 10).Value = matricula.Student.DateOfBirth;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryAtuString, connection);
                try
                {
                    command.Parameters.Add("@CourseId", SqlDbType.VarChar, 5).Value = matricula.CourseId;
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