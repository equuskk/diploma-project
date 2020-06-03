using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.GroundTypes.Queries
{
    public class GetAllGroundTypesQueryHandler : IRequestHandler<GetAllGroundTypesQuery, GroundType[]>
    {
        private readonly ApplicationDbContext _context;

        public GetAllGroundTypesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<GroundType[]> Handle(GetAllGroundTypesQuery request, CancellationToken cancellationToken)
        {
            return _context.GroundTypes.ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllGroundTypesQuery : IRequest<GroundType[]>
    {
        
    }
}