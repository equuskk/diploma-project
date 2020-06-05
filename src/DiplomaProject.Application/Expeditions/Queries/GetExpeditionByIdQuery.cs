using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.DTOs;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Expeditions.Queries
{
    public class GetExpeditionByIdQueryHandler : IRequestHandler<GetExpeditionByIdQuery, ExpeditionDto>
    {
        private readonly ApplicationDbContext _context;

        public GetExpeditionByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExpeditionDto> Handle(GetExpeditionByIdQuery request, CancellationToken cancellationToken)
        {
            var expedition = await _context.Expeditions.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(expedition is null)
            {
                throw new NotFoundException(request.Id, nameof(Expedition));
            }

            var employees = await _context.EmployeeExpeditions
                                          .Where(x => x.ExpeditionId == request.Id)
                                          .Include(x => x.Employee)
                                          .Select(x => new EmployeeDto
                                          {
                                              Id = x.Employee.Id,
                                              FirstName = x.Employee.FirstName,
                                              LastName = x.Employee.LastName,
                                              MidName = x.Employee.MidName,
                                              Sex = x.Employee.Sex,
                                              BirthDay = x.Employee.BirthDay,
                                              EmploymentDate = x.Employee.EmploymentDate
                                          })
                                          .ToArrayAsync(cancellationToken);

            var sectors = await _context.ExpeditionSectors
                                        .Where(x => x.ExpeditionId == request.Id)
                                        .Include(x => x.Sector)
                                        .Select(x => x.Sector)
                                        .ToArrayAsync(cancellationToken);

            var sectorIds = sectors.Select(x => x.Id).ToArray();

            var thickets = await _context.Thickets
                                         .Where(x => sectorIds.Any(sector => sector == x.SectorId) &&
                                                     expedition.FromDate < x.Date &&
                                                     expedition.ToDate > x.Date)
                                         .Include(x => x.Seaweed)
                                         .Include(x => x.GroundType)
                                         .Include(x => x.Litoral)
                                         .Include(x => x.Sector)
                                         .ToArrayAsync(cancellationToken);

            return new ExpeditionDto
            {
                FromDate = expedition.FromDate,
                ToDate = expedition.ToDate,
                Employees = employees,
                Sectors = sectors,
                Thickets = thickets
            };
        }
    }

    public class GetExpeditionByIdQuery : IRequest<ExpeditionDto>
    {
        public int Id { get; set; }
    }
}