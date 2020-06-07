using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.DTOs;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.Employees.Queries
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, EmployeeDto[]>
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;

        public GetAllEmployeesQueryHandler(ApplicationDbContext context, UserManager<Employee> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<EmployeeDto[]> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employeesDtoList = new List<EmployeeDto>();

            var employees = await _context.Users.ToArrayAsync(cancellationToken);

            foreach(var employee in employees)
            {
                var role = await _userManager.GetRolesAsync(employee);
                employeesDtoList.Add(new EmployeeDto
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MidName = employee.MidName,
                    Sex = employee.Sex,
                    BirthDay = employee.BirthDay,
                    EmploymentDate = employee.EmploymentDate,
                    Role = string.Join(",", role ?? new string[] { })
                });
            }

            return employeesDtoList.ToArray();
        }
    }

    public class GetAllEmployeesQuery : IRequest<EmployeeDto[]>
    {
    }
}