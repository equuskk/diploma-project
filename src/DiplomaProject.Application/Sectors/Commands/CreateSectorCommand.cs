using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Serilog;

namespace DiplomaProject.Application.Sectors.Commands
{
    public class CreateSectorCommandHandler : IRequestHandler<CreateSectorCommand, Sector>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public CreateSectorCommandHandler(ApplicationDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<CreateSectorCommandHandler>();
        }

        public async Task<Sector> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Создание нового сектора");
            var sector = new Sector(request.Square, request.LitoralId);
            await _context.Sectors.AddAsync(sector, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.Debug("Создан сектор с ID {SectorId}", sector.Id);

            return sector;
        }
    }

    public class CreateSectorCommand : IRequest<Sector>
    {
        public float Square { get; set; }
        public int LitoralId { get; set; }
    }
}