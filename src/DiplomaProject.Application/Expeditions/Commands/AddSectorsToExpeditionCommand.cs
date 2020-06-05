using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;

namespace DiplomaProject.Application.Expeditions.Commands
{
    public class AddSectorsToExpeditionCommandHandler : IRequestHandler<AddSectorsToExpeditionCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public AddSectorsToExpeditionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddSectorsToExpeditionCommand request, CancellationToken cancellationToken)
        {
            var items = request.SectorIds.Select(sectorId => new ExpeditionSector
            {
                ExpeditionId = request.ExpeditionId,
                SectorId = sectorId
            });

            await _context.ExpeditionSectors.AddRangeAsync(items, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class AddSectorsToExpeditionCommand : IRequest<Unit>
    {
        public int ExpeditionId { get; set; }
        public int[] SectorIds { get; set; }
    }
}