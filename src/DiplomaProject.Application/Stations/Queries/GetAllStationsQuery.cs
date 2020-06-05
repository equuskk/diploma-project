using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Stations.Queries
{
    public class GetAllStationsQueryHandler : IRequestHandler<GetAllStationsQuery, Station[]>
    {
        private readonly ApplicationDbContext _context;

        public GetAllStationsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Station[]> Handle(GetAllStationsQuery request, CancellationToken cancellationToken)
        {
            return _context.Stations.ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllStationsQuery : IRequest<Station[]>
    {
    }
}