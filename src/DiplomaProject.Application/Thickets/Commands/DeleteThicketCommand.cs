using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Thickets.Commands
{
    public class DeleteThicketCommandHandler : IRequestHandler<DeleteThicketCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteThicketCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteThicketCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Thickets.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(item is null)
            {
                throw new NotFoundException(request.Id, nameof(Thicket));
            }

            _context.Thickets.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class DeleteThicketCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}