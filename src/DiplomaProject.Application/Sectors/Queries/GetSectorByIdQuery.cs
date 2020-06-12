using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Sectors.Queries
{
    public class GetSectorByIdQueryHandler : IRequestHandler<GetSectorByIdQuery, Sector>
    {
        private readonly ApplicationDbContext _context;

        public GetSectorByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sector> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
        {
            var sector = await _context.Sectors.Include(x => x.Thickets)
                                       .Include(x => x.Expeditions)
                                       .SingleOrDefaultAsync(x => x.Id == request.SectorId, cancellationToken);
            if(sector is null)
            {
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