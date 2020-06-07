using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.StationsData.Commands
{
    public class DeleteStationDataCommandHandler : IRequestHandler<DeleteStationDataCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteStationDataCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteStationDataCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.StationsData.SingleOrDefaultAsync(x => x.Id == request.StationDataId, cancellationToken);

            if(item is null)
            {
                throw new NotFoundException(request.StationDataId, nameof(StationData));
            }

            _context.StationsData.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class DeleteStationDataCommand : IRequest<Unit>
    {
        public int StationDataId { get; set; }
    }
}