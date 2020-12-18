using MediatR;

namespace CourseSignUp.Services.Commands.Statistics
{
    public class GetByIdStatisticsQuery : IRequest<Domain.Entities.Statistics>
    {
        public string Id { get; private set; }

        public GetByIdStatisticsQuery(string id)
        {
            Id = id;
        }
    }
}
