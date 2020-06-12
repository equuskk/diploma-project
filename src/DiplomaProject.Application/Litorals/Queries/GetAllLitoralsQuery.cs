using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Litorals.Queries
{
    public class GetAllLitoralsQueryHandler : IRequestHandler<GetAllLitoralsQuery, Litoral[]>
    {
        private readonly ApplicationDbContext _context;

        public GetAllLitoralsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Litoral[]> Handle(GetAllLitoralsQuery request, CancellationToken cancellationToken)
        {
            return _context.Litorals.ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllLitoralsQuery : IRequest<Litoral[]>
    {
    }
}