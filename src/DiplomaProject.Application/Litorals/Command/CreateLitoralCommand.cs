using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;

namespace DiplomaProject.Application.Litorals.Command
{
    public class CreateLitoralCommandHandler : IRequestHandler<CreateLitoralCommand, Litoral>
    {
        private readonly ApplicationDbContext _context;

        public CreateLitoralCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Litoral> Handle(CreateLitoralCommand request, CancellationToken cancellationToken)
        {
            var item = new Litoral(request.Title);

            await _context.AddAsync(item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }
    }

    public class CreateLitoralCommand : IRequest<Litoral>
    {
        public string Title { get; set; }
    }
}