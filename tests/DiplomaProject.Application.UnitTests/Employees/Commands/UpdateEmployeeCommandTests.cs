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
    public class UpdateEmployeeCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldThrowException_BecauseUserIdIsIncorrect()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
               .ReturnsAsync(() => null);

            var command = new UpdateEmployeeCommand
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MidName = "Иванович",
                BirthDay = new DateTime(1980, 01, 01),
                EmploymentDate = new DateTime(2019, 01, 01),
                Id = Guid.NewGuid().ToString()
            };

            var handler = new UpdateEmployeeCommandHandler(mgr.Object);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task ShouldUpdateEmployee()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
               .ReturnsAsync(Employee);
            mgr.Setup(x => x.UpdateAsync(It.IsAny<Employee>()))
               .ReturnsAsync(IdentityResult.Success);

            var command = new UpdateEmployeeCommand
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MidName = "Иванович",
                BirthDay = new DateTime(1980, 01, 01),
                EmploymentDate = new DateTime(2019, 01, 01),
                Id = UserId
            };
            var handler = new UpdateEmployeeCommandHandler(mgr.Object);

            _ = await handler.Handle(command, CancellationToken.None);
        }
    }
}