using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Seaweeds.Commands
{
    public class DeleteSeaweedCommandHandler : IRequestHandler<DeleteSeaweedCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteSeaweedCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSeaweedCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Seaweeds.SingleOrDefaultAsync(x => x.Id == request.SeaweedId,
                                                                    cancellationToken);
            if(item is null)
            {
                throw new NotFoundException(request.SeaweedId, nameof(Seaweed));
            }

            _context.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class DeleteSeaweedCommand : IRequest<Unit>
    {
        public int SeaweedId { get; set; }
    }
}