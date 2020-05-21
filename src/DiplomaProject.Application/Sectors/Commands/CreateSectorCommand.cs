using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;

namespace DiplomaProject.Application.Sectors.Commands
{
    public class CreateSectorCommandHandler : IRequestHandler<CreateSectorCommand, Sector>
    {
        private readonly ApplicationDbContext _context;

        public CreateSectorCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sector> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
        {
            var sector = new Sector(request.Square, request.LitoralId);
            await _context.Sectors.AddAsync(sector, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return sector;
        }
    }

    public class CreateSectorCommand : IRequest<Sector>
    {
        public float Square { get; set; }
        public int LitoralId { get; set; }
    }
}