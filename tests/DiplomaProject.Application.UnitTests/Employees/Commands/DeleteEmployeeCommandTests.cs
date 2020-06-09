using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Employees.Commands;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Employees.Commands
{
    public class DeleteEmployeeCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteEmployee()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
               .ReturnsAsync(Employee);
            mgr.Setup(x => x.DeleteAsync(It.IsAny<Employee>()))
               .ReturnsAsync(IdentityResult.Success);

            var command = new DeleteEmployeeCommand
            {
                EmployeeId = UserId
            };
            var handler = new DeleteEmployeeCommandHandler(mgr.Object);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseUserIdIsIncorrect()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
               .ReturnsAsync(() => null);

            var command = new DeleteEmployeeCommand
            {
                EmployeeId = Guid.NewGuid().ToString()
            };
            var handler = new DeleteEmployeeCommandHandler(mgr.Object);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}