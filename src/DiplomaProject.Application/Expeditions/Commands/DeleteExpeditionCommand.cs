using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Expeditions.Commands
{
    public class DeleteExpeditionCommandHandler : IRequestHandler<DeleteExpeditionCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteExpeditionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExpeditionCommand request, CancellationToken cancellationToken)
        {
            var expedition = await _context.Expeditions.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(expedition is null)
            {
                throw new NotFoundException(request.Id, nameof(Expedition));
            }

            _context.Expeditions.Remove(expedition);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }

    public class DeleteExpeditionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}