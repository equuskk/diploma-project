using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Employees.Queries
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, EmployeeDto[]>
    {
        private readonly ApplicationDbContext _context;

        public GetAllEmployeesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<EmployeeDto[]> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return _context.Users.Select(x => new EmployeeDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MidName = x.MidName,
                Sex = x.Sex,
                BirthDay = x.BirthDay,
                EmploymentDate = x.EmploymentDate
            }).ToArrayAsync(cancellationToken);
        }
    }

    public class GetAllEmployeesQuery : IRequest<EmployeeDto[]>
    {
    }
}