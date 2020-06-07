using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.GroundTypes.Command
{
    public class DeleteGroundTypeCommandHandler : IRequestHandler<DeleteGroundTypeCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteGroundTypeCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGroundTypeCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.GroundTypes.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(item is null)
            {
                throw new NotFoundException(request.Id, nameof(GroundType));
            }

            _context.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class DeleteGroundTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}