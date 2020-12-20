using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Repository;
using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace CourseSignUp.Infra.Repository
{
    public class SignUpToCourseRepository : ISignUpToCourseRepository
    {
        private readonly IConfiguration _configuration;
        private IStudentRepository _StudentRepository;
        private ICourseSignUpRepository _CourseRepository;


        public SignUpToCourseRepository(IConfiguration configuration , IStudentRepository studentRepository , ICourseSignUpRepository courseRepository )
        {
            _configuration = configuration;
            _StudentRepository = studentRepository;
            _CourseRepository = courseRepository;
        }

        public IEnumerable<Student> GetIdStudentsByCourse(int id)
        {
            //Listar todos os alunos do curso
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString = " SELECT StudentId " +
                                 " FROM dbo.SignUPToCourse " +
                                 " WHERE CourseId = @Id ";

            var students = new List<Student>();
            var student = new Student();

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@Id", SqlDbType.Int ).Value = id;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        student = _StudentRepository.Get(reader.GetInt32(0)) ;

                        if (student.StudentId == 0)
                        {
                            throw new ArgumentException("Nenhum aluno encontrado para o curso");
                        }
                        else
                        {
                            students.Add(new Student()
                            {
                                StudentId = student.StudentId,
                                DateOfBirth = student.DateOfBirth,
                                Email = student.Email,
                                StudentName = student.StudentName
                            });
                        }   
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return students;   
        } 

        public SignUpToCourse Get(int id )
        {
            var signupretorno = new SignUpToCourse();
            var course = new Course();
            course = _CourseRepository.Get(id);

            if (course.CourseId == 0)
            {
                throw new ArgumentException("Curso não encontrado");
            }
            else 
            {
               signupretorno.Course = new Course { CourseId = course.CourseId, Capacity = course.Capacity, CourseName = course.CourseName, NumberOfStudents = course.NumberOfStudents };
               var alumns = GetIdStudentsByCourse(id);
               signupretorno.Student = alumns;
            }
          
            return signupretorno;
        }

        public bool Create(int IdCourse , int IdStudent)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            var course = new Course();
            var student = new Student();
            
            string queryString =
              "  INSERT INTO dbo.SignUPToCourse(CourseId, StudentId) " +
                "VALUES(@CourseId, @StudentId)";

            course = _CourseRepository.Get(IdCourse);
            if (course.NumberOfStudents >= course.Capacity )
            {
                throw new ArgumentException("Capacidade excedida curso : " + course.CourseName);
            }

            if (course.CourseId == 0)
            {
                throw new ArgumentException("Curso não encontrado!");
            }

            student = _StudentRepository.Get(IdStudent);
            if (student.StudentId == 0)
            {
                throw new ArgumentException("Aluno não encontrado!");
            }

            if ( VerifySignUp(IdCourse , IdStudent))
            {
                throw new ArgumentException("Matrícula já incluída!");
            }

            using (SqlConnection connection =
             new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@CourseId", SqlDbType.Int).Value = IdCourse;
                    command.Parameters.Add("@StudentId", SqlDbType.Int).Value = IdStudent;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    _CourseRepository.UpdateNumberStudents(IdCourse);
                }
                catch (Exception )
                {
                    throw;
                }
            }
            return true; 
        }

        public bool VerifySignUp(int IdCourse , int IdStudent)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            string queryString = " select SignUPId " +
                                 " from dbo.SignUPToCourse " +
                                 " where CourseId = @IdCourse " +
                                 " and StudentId = @IdStudent ";
            int qtdSignUp = 0;

            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@IdCourse", SqlDbType.Int).Value = IdCourse;
                    command.Parameters.Add("@IdStudent", SqlDbType.Int).Value = IdStudent;
                    connection.Open();
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetValue(0) != DBNull.Value)
                            qtdSignUp = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (qtdSignUp == 0)
                return false;
            else
                return true;
        }

    }
}
