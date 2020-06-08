using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiplomaProject.Application.Employees.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly UserManager<Employee> _userManager;

        public DeleteEmployeeCommandHandler(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var item = await _userManager.FindByIdAsync(request.EmployeeId);
            if(item is null)
            {
                throw new NotFoundException(request.EmployeeId, nameof(Employee));
            }

            var deleteResult = await _userManager.DeleteAsync(item);
            if(deleteResult.Succeeded)
            {
                return Unit.Value;
            }

            throw new ArgumentException(); // TODO:
        }
    }

    public class DeleteEmployeeCommand : IRequest<Unit>
    {
        public string EmployeeId { get; set; }
    }
}