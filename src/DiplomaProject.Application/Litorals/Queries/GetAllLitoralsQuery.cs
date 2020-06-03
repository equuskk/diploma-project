using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DiplomaProject.Application.Litorals.Queries
{
    public class GetAllLitoralsQueryHandler : IRequestHandler<GetAllLitoralsQuery, Litoral[]>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public GetAllLitoralsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<GetAllLitoralsQuery>();
        }

        public Task<Litoral[]> Handle(GetAllLitoralsQuery request, CancellationToken cancellationToken)
        {
            _logger.Debug("Получение списка всех литоралей");
            return _context.Litorals.ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllLitoralsQuery : IRequest<Litoral[]>
    {
    }
}