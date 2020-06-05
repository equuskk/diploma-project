using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;

namespace DiplomaProject.Application.Expeditions.Commands
{
    public class AddEmployeesToExpeditionCommandHandler : IRequestHandler<AddEmployeesToExpeditionCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public AddEmployeesToExpeditionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddEmployeesToExpeditionCommand request, CancellationToken cancellationToken)
        {
            var items = request.UserIds.Select(userId => new EmployeeExpedition
            {
                ExpeditionId = request.ExpeditionId,
                EmployeeId = userId
            });

            await _context.EmployeeExpeditions.AddRangeAsync(items, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class AddEmployeesToExpeditionCommand : IRequest<Unit>
    {
        public int ExpeditionId { get; set; }
        public string[] UserIds { get; set; }
    }
}