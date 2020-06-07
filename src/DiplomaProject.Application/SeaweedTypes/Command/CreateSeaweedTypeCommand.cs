using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;

namespace DiplomaProject.Application.SeaweedTypes.Command
{
    public class CreateSeaweedTypeCommandHandler : IRequestHandler<CreateSeaweedTypeCommand, SeaweedType>
    {
        private readonly ApplicationDbContext _context;

        public CreateSeaweedTypeCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SeaweedType> Handle(CreateSeaweedTypeCommand request, CancellationToken cancellationToken)
        {
            var item = new SeaweedType(request.Title);

            await _context.AddAsync(item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }
    }

    public class CreateSeaweedTypeCommand : IRequest<SeaweedType>
    {
        public string Title { get; set; }
    }
}