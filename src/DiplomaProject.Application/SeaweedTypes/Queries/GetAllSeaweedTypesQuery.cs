using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.SeaweedTypes.Queries
{
    public class GetAllSeaweedTypesQueryHandler : IRequestHandler<GetAllSeaweedTypesQuery, SeaweedType[]>
    {
        private readonly ApplicationDbContext _context;

        public GetAllSeaweedTypesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<SeaweedType[]> Handle(GetAllSeaweedTypesQuery request, CancellationToken cancellationToken)
        {
            return _context.SeaweedTypes.ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllSeaweedTypesQuery : IRequest<SeaweedType[]>
    {
    }
}