using MediatR;

namespace CourseSignUp.Services.Commands.Statistics
{
    public class GetByIdStatisticsQuery : IRequest<Domain.Entities.Statistics>
    {
        public int Id { get; private set; }

        public GetByIdStatisticsQuery(int id)
        {
            Id = id;
        }
    }
}
