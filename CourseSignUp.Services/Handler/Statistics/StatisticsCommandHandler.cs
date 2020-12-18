using CourseSignUp.Domain.Repository;
using CourseSignUp.Services.Commands.Statistics;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignUp.Services.Handler.Statistics
{
    public class StatisticsCommandHandler : 
        IRequestHandler<GetAllStatisticsQuery, IEnumerable<Domain.Entities.Statistics>>,
        IRequestHandler<GetByIdStatisticsQuery, Domain.Entities.Statistics>
    {
        private readonly IStatisticsRepository _StatisticsRepository;

        public StatisticsCommandHandler(
            IStatisticsRepository statisticsRepository)
        {
            _StatisticsRepository = statisticsRepository;
        }

        public Task<IEnumerable<Domain.Entities.Statistics>> Handle(GetAllStatisticsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _StatisticsRepository.GetAll()
            );
        }

        public Task<Domain.Entities.Statistics> Handle(GetByIdStatisticsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _StatisticsRepository.Get(request.Id)
            );
        }
    }
}
