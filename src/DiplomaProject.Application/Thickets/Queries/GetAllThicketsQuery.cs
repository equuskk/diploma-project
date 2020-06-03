using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Thickets.Queries
{
    public class GetAllThicketsQueryHandler : IRequestHandler<GetAllThicketsQuery, Thicket[]>
    {
        private readonly ApplicationDbContext _context;

        public GetAllThicketsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Thicket[]> Handle(GetAllThicketsQuery request, CancellationToken cancellationToken)
        {
            return _context.Thickets
                           .Include(x => x.Litoral)
                           .Include(x => x.Seaweed)
                           .Include(x => x.Sector)
                           .Include(x => x.GroundType)
                           .ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllThicketsQuery : IRequest<Thicket[]>
    {
    }
}