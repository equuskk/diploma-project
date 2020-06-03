using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Seaweeds.Queries
{
    public class GetAllSeaweedsQueryHandler : IRequestHandler<GetAllSeaweedsQuery, Seaweed[]>
    {
        private readonly ApplicationDbContext _context;

        public GetAllSeaweedsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Seaweed[]> Handle(GetAllSeaweedsQuery request, CancellationToken cancellationToken)
        {
            return _context.Seaweeds.Include(x => x.Category)
                           .Include(x => x.Type)
                           .ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllSeaweedsQuery : IRequest<Seaweed[]>
    {
    }
}