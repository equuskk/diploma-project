using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;

namespace DiplomaProject.Application.Seaweeds.Commands
{
    public class CreateSeaweedCommandHandler : IRequestHandler<CreateSeaweedCommand, Seaweed>
    {
        private readonly ApplicationDbContext _context;

        public CreateSeaweedCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Seaweed> Handle(CreateSeaweedCommand request, CancellationToken cancellationToken)
        {
            var seaweed = new Seaweed
            {
                Title = request.Title,
                SeaweedCategoryId = request.SeaweedCategoryId,
                SeaweedTypeId = request.SeaweedTypeId
            };

            await _context.Seaweeds.AddAsync(seaweed, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return seaweed;
        }
    }

    public class CreateSeaweedCommand : IRequest<Seaweed>
    {
        public string Title { get; set; }

        public int SeaweedTypeId { get; set; }
        public int SeaweedCategoryId { get; set; }
    }
}