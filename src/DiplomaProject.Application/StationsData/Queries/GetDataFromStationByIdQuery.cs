using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.StationsData.Queries
{
    public class GetDataFromStationByIdQueryHandler : IRequestHandler<GetDataFromStationByIdQuery, StationData[]>
    {
        private readonly ApplicationDbContext _context;

        public GetDataFromStationByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StationData[]> Handle(GetDataFromStationByIdQuery request, CancellationToken cancellationToken)
        {
            var isStationExists = await _context.Stations.AnyAsync(x => x.Id == request.StationId, cancellationToken);
            if(!isStationExists)
            {
                throw new NotFoundException(request.StationId, nameof(Station));
            }

            var data = await _context.StationsData.Where(x => x.StationId == request.StationId)
                                     .ToArrayAsync(cancellationToken);

            return data;
        }
    }

    public class GetDataFromStationByIdQuery : IRequest<StationData[]>
    {
        public int StationId { get; set; }
    }
}