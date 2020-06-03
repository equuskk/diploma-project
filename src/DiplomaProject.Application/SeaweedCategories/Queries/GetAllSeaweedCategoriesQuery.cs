using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.SeaweedCategories.Queries
{
    public class GetAllSeaweedCategoriesQueryHandler : IRequestHandler<GetAllSeaweedCategoriesQuery, SeaweedCategory[]>
    {
        private readonly ApplicationDbContext _context;

        public GetAllSeaweedCategoriesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<SeaweedCategory[]> Handle(GetAllSeaweedCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _context.SeaweedCategories.ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllSeaweedCategoriesQuery : IRequest<SeaweedCategory[]>
    {
    }
}