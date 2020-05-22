using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DiplomaProject.Application.Litorals.Queries
{
    public class GetAllLitoralsHandler : IRequestHandler<GetAllLitorals, Litoral[]>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public GetAllLitoralsHandler(ApplicationDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<GetAllLitorals>();
        }

        public Task<Litoral[]> Handle(GetAllLitorals request, CancellationToken cancellationToken)
        {
            _logger.Debug("Получение списка всех литоралей");
            return _context.Litorals.ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllLitorals : IRequest<Litoral[]>
    {
    }
}