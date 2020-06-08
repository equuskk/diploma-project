using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Sectors.Commands
{
    public class UpdateSectorCommandHandler : IRequestHandler<UpdateSectorCommand, Sector>
    {
        private readonly ApplicationDbContext _context;

        public UpdateSectorCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sector> Handle(UpdateSectorCommand request, CancellationToken cancellationToken)
        {
            var sector = await _context.Sectors.SingleOrDefaultAsync(x => x.Id == request.SectorId, cancellationToken);
            if(sector is null)
            {
                throw new NotFoundException(request.SectorId, nameof(Sector));
            }

            sector.Title = request.Title;
            sector.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return sector;
        }
    }

    public class UpdateSectorCommand : IRequest<Sector>
    {
        public int SectorId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}