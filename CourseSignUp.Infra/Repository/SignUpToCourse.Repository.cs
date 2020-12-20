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

                /*
               foreach ( Student item in alumns)
               {
                  signupretorno.Student = new Student { StudentId = item.StudentId, 
                                                        DateOfBirth = item.DateOfBirth, 
                                                        Email = item.Email, 
                                                        StudentName = item.StudentName };
               }*/
            }
          
            return signupretorno;
        }

        public bool Create(SignUpToCourse courseSignUpToCourse)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionCourse");
            var signupretorno = new SignUpToCourse();
            var course = new Course();
            var student = new Student();
            
            string queryString =
              "  INSERT INTO dbo.SignUPToCourse(CourseId, StudentId) " +
                "VALUES(@CourseId, @StudentId)";

            course = _CourseRepository.Get(courseSignUpToCourse.CourseId);

            if (course.CheckCapacity())
            {
                throw new ArgumentException("Capacidade excedida curso : " + course.CourseName);
            }

            if (course.CourseId == 0)
            {
                throw new ArgumentException("Curso não encontrado");
            }

            student = _StudentRepository.Get(courseSignUpToCourse.StudentId);
            if (course.CourseId == 0)
            {
                throw new ArgumentException("Aluno não encontrado");
            }

            using (SqlConnection connection =
             new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@CourseId", SqlDbType.Int).Value = courseSignUpToCourse.CourseId;
                    command.Parameters.Add("@StudentId", SqlDbType.Int).Value = courseSignUpToCourse.StudentId;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    _CourseRepository.UpdateNumberStudents(courseSignUpToCourse.CourseId);
                }
                catch (Exception )
                {
                    throw;
                }
            }
            return true; 
        }
    }
}
