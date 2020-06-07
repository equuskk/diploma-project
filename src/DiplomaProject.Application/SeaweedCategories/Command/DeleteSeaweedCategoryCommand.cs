using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.SeaweedCategories.Command
{
    public class DeleteSeaweedCategoryCommandHandler : IRequestHandler<DeleteSeaweedCategoryCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteSeaweedCategoryCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSeaweedCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.SeaweedCategories.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(item is null)
            {
                throw new NotFoundException(request.Id, nameof(SeaweedCategory));
            }

            _context.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class DeleteSeaweedCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}