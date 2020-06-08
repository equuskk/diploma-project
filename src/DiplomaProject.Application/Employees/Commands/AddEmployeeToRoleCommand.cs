using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiplomaProject.Application.Employees.Commands
{
    public class AddEmployeeToRoleCommandHandler : IRequestHandler<AddEmployeeToRoleCommand, Unit>
    {
        private readonly UserManager<Employee> _userManager;

        public AddEmployeeToRoleCommandHandler(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(AddEmployeeToRoleCommand request, CancellationToken cancellationToken)
        {
            var employee = await _userManager.FindByIdAsync(request.EmployeeId);
            if(employee is null)
            {
                throw new NotFoundException(request.EmployeeId, nameof(Employee));
            }

            var employeeRoles = await _userManager.GetRolesAsync(employee);
            await _userManager.RemoveFromRolesAsync(employee, employeeRoles);

            var result = await _userManager.AddToRoleAsync(employee, request.RoleName);
            if(!result.Succeeded)
            {
                throw new ArgumentException("Некорректное имя роли", nameof(request.RoleName));
            }

            return Unit.Value;
        }
    }

    public class AddEmployeeToRoleCommand : IRequest<Unit>
    {
        public string EmployeeId { get; set; }
        public string RoleName { get; set; }
    }
}