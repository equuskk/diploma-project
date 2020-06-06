using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using NetTopologySuite.Geometries;

namespace DiplomaProject.Application.Stations.Commands
{
    public class CreateStationCommandHandler : IRequestHandler<CreateStationCommand, Station>
    {
        private readonly ApplicationDbContext _context;

        public CreateStationCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Station> Handle(CreateStationCommand request, CancellationToken cancellationToken)
        {
            var item = new Station
            {
                Location = request.Location,
                SectorId = request.SectorId,
                Title = request.Title
            };
            await _context.Stations.AddAsync(item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }
    }

    public class CreateStationCommand : IRequest<Station>
    {
        public string Title { get; set; }
        public Point Location { get; set; }
        public int SectorId { get; set; }

        public CreateStationCommand()
        {
            Location = new Point(0, 0);
        }
    }
}