using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Employees.Commands;
using DiplomaProject.Domain;
using DiplomaProject.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Employees.Commands
{
    public class CreateEmployeeCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateEmployee()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(x => x.CreateAsync(It.IsAny<Employee>(), It.IsAny<string>()))
               .ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.AddToRoleAsync(It.IsAny<Employee>(), It.IsAny<string>()))
               .ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
               .ReturnsAsync(Employee);

            var command = new CreateEmployeeCommand
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MidName = "Иванович",
                BirthDay = new DateTime(1980, 01, 01),
                Sex = Sex.Male,
                EmploymentDate = new DateTime(2019, 01, 01),
                Email = "ivan@company.com",
                Password = "123456"
            };
            var handler = new CreateEmployeeCommandHandler(mgr.Object);

            var result = await handler.Handle(command, CancellationToken.None);
            result.Should().Be(IdentityResult.Success);
        }
    }
}