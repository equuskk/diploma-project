using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Litorals.Command
{
    public class DeleteLitoralCommandHandler : IRequestHandler<DeleteLitoralCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteLitoralCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLitoralCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Litorals.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(item is null)
            {
                throw new NotFoundException(request.Id, nameof(Litoral));
            }

            _context.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class DeleteLitoralCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}