using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Stations.Commands
{
    public class DeleteStationCommandHandler : IRequestHandler<DeleteStationCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteStationCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteStationCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Stations.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(item is null)
            {
                throw new NotFoundException(request.Id, nameof(Station));
            }

            _context.Stations.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class DeleteStationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}