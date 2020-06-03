using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;
using NetTopologySuite.Geometries;

namespace DiplomaProject.Application.Thickets.Commands
{
    public class CreateThicketCommandHandler : IRequestHandler<CreateThicketCommand, Thicket>
    {
        private readonly ApplicationDbContext _context;

        public CreateThicketCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Thicket> Handle(CreateThicketCommand request, CancellationToken cancellationToken)
        {
            var thicket = new Thicket
            {
                Location = request.Location,
                Date = request.Date,
                WeightPerMeter = request.WeightPerMeter,
                Length = request.Length,
                Width = request.Width,
                Stock = request.WeightPerMeter * request.Length * request.Width,
                LitoralId = request.LitoralId,
                GroundTypeId = request.GroundTypeId,
                SeaweedId = request.SeaweedId,
                SectorId = request.SectorId
            };

            await _context.Thickets.AddAsync(thicket, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return thicket;
        }
    }

    public class CreateThicketCommand : IRequest<Thicket>
    {
        public Point Location { get; set; }
        public DateTimeOffset Date { get; set; }
        public float WeightPerMeter { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }

        public int LitoralId { get; set; }
        public int GroundTypeId { get; set; }
        public int SeaweedId { get; set; }
        public int SectorId { get; set; }

        public CreateThicketCommand()
        {
            Location = new Point(0, 0);
        }
    }
}