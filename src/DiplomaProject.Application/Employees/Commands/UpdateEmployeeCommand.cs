using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiplomaProject.Application.Employees.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly UserManager<Employee> _userManager;

        public UpdateEmployeeCommandHandler(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _userManager.FindByIdAsync(request.Id);
            if(employee is null)
            {
                throw new NotFoundException(request.Id, nameof(Employee));
            }

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.MidName = request.MidName;
            employee.BirthDay = request.BirthDay;
            employee.EmploymentDate = request.EmploymentDate;

            await _userManager.UpdateAsync(employee);

            return Unit.Value;
        }
    }

    public class UpdateEmployeeCommand : IRequest<Unit>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public DateTimeOffset BirthDay { get; set; }
        public DateTimeOffset EmploymentDate { get; set; }
    }
}