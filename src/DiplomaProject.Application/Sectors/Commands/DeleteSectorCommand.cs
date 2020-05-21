using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Sectors.Commands
{
    public class DeleteSectorCommandHandler : IRequestHandler<DeleteSectorCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteSectorCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
        {
            var sector = await _context.Sectors.SingleOrDefaultAsync(x => x.Id == request.SectorId, cancellationToken);
            if(sector is null)
            {
                throw new NotFoundException(request.SectorId, nameof(Sector));
            }

            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class DeleteSectorCommand : IRequest<Unit>
    {
        public int SectorId { get; set; }
    }
}