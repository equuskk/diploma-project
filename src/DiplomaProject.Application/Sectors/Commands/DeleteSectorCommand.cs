using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DiplomaProject.Application.Sectors.Commands
{
    public class DeleteSectorCommandHandler : IRequestHandler<DeleteSectorCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public DeleteSectorCommandHandler(ApplicationDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<DeleteSectorCommandHandler>();
        }

        public async Task<Unit> Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Удаление сектора с Id {SectorId}", request.SectorId);
            var sector = await _context.Sectors.SingleOrDefaultAsync(x => x.Id == request.SectorId, cancellationToken);
            if(sector is null)
            {
                _logger.Warning("Сектор с Id {SectorId} не найден", request.SectorId);
                throw new NotFoundException(request.SectorId, nameof(Sector));
            }

            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.Information("Удалён сектор с Id {SectorId}", request.SectorId);

            return Unit.Value;
        }
    }

    public class DeleteSectorCommand : IRequest<Unit>
    {
        public int SectorId { get; set; }
    }
}