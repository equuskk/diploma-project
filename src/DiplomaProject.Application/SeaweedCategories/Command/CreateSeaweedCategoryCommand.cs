using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;

namespace DiplomaProject.Application.SeaweedCategories.Command
{
    public class CreateSeaweedCategoryCommandHandler : IRequestHandler<CreateSeaweedCategoryCommand, SeaweedCategory>
    {
        private readonly ApplicationDbContext _context;

        public CreateSeaweedCategoryCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SeaweedCategory> Handle(CreateSeaweedCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = new SeaweedCategory(request.Title);

            await _context.AddAsync(item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }
    }

    public class CreateSeaweedCategoryCommand : IRequest<SeaweedCategory>
    {
        public string Title { get; set; }
    }
}