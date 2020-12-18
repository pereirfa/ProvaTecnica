using MediatR;
using System.Collections.Generic;

namespace CourseSignUp.Services.Commands.Statistics
{
    public class GetAllStatisticsQuery : IRequest<IEnumerable<Domain.Entities.Statistics>>
    {}
}
