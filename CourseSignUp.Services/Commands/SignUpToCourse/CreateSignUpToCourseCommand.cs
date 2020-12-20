using MediatR;

namespace CourseSignUp.Services.Commands.SignUpToCourse
{
    public class CreateSignUpToCourseCommand : IRequest<bool>
    {
        public int IdCourse { get; private set; }

        public int IdStudent { get; private set; }


        public CreateSignUpToCourseCommand(int idCourse , int idStudent)
        {
            IdCourse = idCourse;
            IdStudent = idStudent;
        }
    }
}
