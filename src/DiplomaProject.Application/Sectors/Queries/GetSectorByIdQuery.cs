using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DiplomaProject.Application.Sectors.Queries
{
    public class GetSectorByIdQueryHandler : IRequestHandler<GetSectorByIdQuery, Sector>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public GetSectorByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<GetSectorByIdQueryHandler>();
        }

        public async Task<Sector> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.Debug("Получение сектора по Id {SectorId}", request.SectorId);
            var sector = await _context.Sectors.Include(x => x.Bioresources)
                                       .Include(x => x.Expeditions)
                                       .SingleOrDefaultAsync(x => x.Id == request.SectorId, cancellationToken);
            if(sector is null)
            {
                _logger.Warning("Сектор с Id {SectorId} не найден", request.SectorId);
                throw new NotFoundException(request.SectorId, nameof(Sector));
            }

            return sector;
        }
    }

    public class GetSectorByIdQuery : IRequest<Sector>
    {
        public int SectorId { get; set; }
    }
}