using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Employees.Queries;
using DiplomaProject.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Employees.Queries
{
    public class GetAllEmployeesQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnDtoUsers()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(a => a.GetRolesAsync(It.IsAny<Employee>()))
               .Returns(Task.FromResult<IList<string>>(new List<string> { "Роль1" }));

            var command = new GetAllEmployeesQuery();
            var handler = new GetAllEmployeesQueryHandler(ApplicationContext, mgr.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().HaveCount(1);
        }
    }
}