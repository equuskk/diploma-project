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
    public class AddEmployeeToRoleCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldAddEmployeeToRole()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
               .ReturnsAsync(Employee);
            mgr.Setup(x => x.GetRolesAsync(It.IsAny<Employee>()))
               .ReturnsAsync(new[] { "Роль1" });
            mgr.Setup(x => x.RemoveFromRolesAsync(It.IsAny<Employee>(), It.IsAny<string[]>()))
               .ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.AddToRoleAsync(It.IsAny<Employee>(), It.IsAny<string>()))
               .ReturnsAsync(IdentityResult.Success);

            var command = new AddEmployeeToRoleCommand
            {
                EmployeeId = UserId,
                RoleName = "Роль1"
            };
            var handler = new AddEmployeeToRoleCommandHandler(mgr.Object);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseRoleNameIsIncorrect()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
               .ReturnsAsync(Employee);
            mgr.Setup(x => x.GetRolesAsync(It.IsAny<Employee>()))
               .ReturnsAsync(new[] { "Роль1" });
            mgr.Setup(x => x.RemoveFromRolesAsync(It.IsAny<Employee>(), It.IsAny<string[]>()))
               .ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.AddToRoleAsync(It.IsAny<Employee>(), It.IsAny<string>()))
               .ReturnsAsync(IdentityResult.Failed());

            var command = new AddEmployeeToRoleCommand
            {
                EmployeeId = UserId,
                RoleName = "Роль1"
            };
            var handler = new AddEmployeeToRoleCommandHandler(mgr.Object);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task ShouldThrowException_BecauseUserIdIsIncorrect()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
               .ReturnsAsync(() => null);

            var command = new AddEmployeeToRoleCommand
            {
                EmployeeId = UserId,
                RoleName = "Роль1"
            };
            var handler = new AddEmployeeToRoleCommandHandler(mgr.Object);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}