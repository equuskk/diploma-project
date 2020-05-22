using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DiplomaProject.Application.Sectors.Queries
{
    public class GetAllSectorsQueryHandler : IRequestHandler<GetAllSectorsQuery, Sector[]>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public GetAllSectorsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<GetAllSectorsQueryHandler>();
        }

        public Task<Sector[]> Handle(GetAllSectorsQuery request, CancellationToken cancellationToken)
        {
            _logger.Debug("Получение всех секторов");
            return _context.Sectors.ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllSectorsQuery : IRequest<Sector[]>
    {
    }
}