using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Sectors.Queries
{
    public class GetAllSectorsQueryHandler : IRequestHandler<GetAllSectorsQuery, Sector[]>
    {
        private readonly ApplicationDbContext _context;

        public GetAllSectorsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Sector[]> Handle(GetAllSectorsQuery request, CancellationToken cancellationToken)
        {
            return _context.Sectors.ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllSectorsQuery : IRequest<Sector[]>
    {
    }
}