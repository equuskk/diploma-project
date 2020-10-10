using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Domain;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiplomaProject.Application.Employees.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, IdentityResult>
    {
        private readonly UserManager<Employee> _userManager;

        public CreateEmployeeCommandHandler(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MidName = request.MidName,
                BirthDay = request.BirthDay,
                EmploymentDate = request.EmploymentDate,
                Email = request.Email,
                UserName = request.Email,
                Sex = request.Sex
            };

            await _userManager.CreateAsync(employee, request.Password);

            await _userManager.AddToRoleAsync(employee, RoleNames.JuniorEmployee);

            return IdentityResult.Success;
        }
    }

    public class CreateEmployeeCommand : IRequest<IdentityResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public Sex Sex { get; set; }
        public DateTimeOffset BirthDay { get; set; }
        public DateTimeOffset EmploymentDate { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
    }
}