using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.DTOs;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Expeditions.Queries
{
    public class GetExpeditionByIdQueryHandler : IRequestHandler<GetExpeditionByIdQuery, ExpeditionDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;

        public GetExpeditionByIdQueryHandler(ApplicationDbContext context, UserManager<Employee> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                                          .Select(x => x.Employee)
                                          .ToArrayAsync(cancellationToken);

            var employeesDto = new List<EmployeeDto>();
            foreach(var employee in employees)
            {
                var roles = await _userManager.GetRolesAsync(employee);
                employeesDto.Add(new EmployeeDto
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MidName = employee.MidName,
                    Sex = employee.Sex,
                    BirthDay = employee.BirthDay,
                    EmploymentDate = employee.EmploymentDate,
                    Role = string.Join(',', roles)
                });
            }

            var sectors = await _context.ExpeditionSectors
                                        .Where(x => x.ExpeditionId == request.Id)
                                        .Include(x => x.Sector)
                                        .Select(x => x.Sector)
                                        .ToArrayAsync(cancellationToken);

            var sectorIds = sectors.Select(x => x.Id).ToArray();

            var thickets = await _context.Thickets
                                         .Include(x => x.Seaweed)
                                         .Include(x => x.GroundType)
                                         .Include(x => x.Litoral)
                                         .Include(x => x.Sector)
                                         .ToArrayAsync(cancellationToken);

            return new ExpeditionDto
            {
                FromDate = expedition.FromDate,
                ToDate = expedition.ToDate,
                Employees = employeesDto.ToArray(),
                Sectors = sectors,
                Thickets = thickets.Where(x => sectorIds.Any(sector => sector == x.SectorId) &&
                                               expedition.FromDate < x.Date &&
                                               expedition.ToDate > x.Date)
                                   .ToArray()
            };
        }
    }

    public class GetExpeditionByIdQuery : IRequest<ExpeditionDto>
    {
        public int Id { get; set; }
    }
}