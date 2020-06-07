using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.StationsData.Commands
{
    public class CreateStationDataCommandHandler : IRequestHandler<CreateStationDataCommand, StationData>
    {
        private readonly ApplicationDbContext _context;

        public CreateStationDataCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StationData> Handle(CreateStationDataCommand request, CancellationToken cancellationToken)
        {
            var isStationExists = await _context.Stations.AnyAsync(x => x.Id == request.StationId, cancellationToken);
            if(!isStationExists)
            {
                throw new NotFoundException(request.StationId, nameof(Station));
            }

            var stationData = new StationData
            {
                Date = request.Date,
                Temperature = request.Temperature,
                Density = request.Density,
                Depth = request.Depth,
                StationId = request.StationId
            };
            await _context.StationsData.AddAsync(stationData, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return stationData;
        }
    }

    public class CreateStationDataCommand : IRequest<StationData>
    {
        public DateTimeOffset Date { get; set; }
        public float Temperature { get; set; }
        public float Density { get; set; }
        public float Depth { get; set; }

        public int StationId { get; set; }

        public CreateStationDataCommand()
        {
            Date = DateTimeOffset.Now;
        }
    }
}