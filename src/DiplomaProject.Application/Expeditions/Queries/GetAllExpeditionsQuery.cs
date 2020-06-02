using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Expeditions.Queries
{
    public class GetAllExpeditionsQueryHandler : IRequestHandler<GetAllExpeditionsQuery, Expedition[]>
    {
        private readonly ApplicationDbContext _context;

        public GetAllExpeditionsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Expedition[]> Handle(GetAllExpeditionsQuery request, CancellationToken cancellationToken)
        {
            return _context.Expeditions.ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllExpeditionsQuery : IRequest<Expedition[]>
    {
    }
}