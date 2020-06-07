using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;

namespace DiplomaProject.Application.GroundTypes.Command
{
    public class CreateGroundTypeCommandHandler : IRequestHandler<CreateGroundTypeCommand, GroundType>
    {
        private readonly ApplicationDbContext _context;

        public CreateGroundTypeCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GroundType> Handle(CreateGroundTypeCommand request, CancellationToken cancellationToken)
        {
            var item = new GroundType(request.Title);

            await _context.AddAsync(item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }
    }

    public class CreateGroundTypeCommand : IRequest<GroundType>
    {
        public string Title { get; set; }
    }
}