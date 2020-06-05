using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Employees.Queries;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Employees.Queries
{
    public class GetAllEmployeesQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnDtoUsers()
        {
            var command = new GetAllEmployeesQuery();
            var handler = new GetAllEmployeesQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().HaveCount(1);
        }
    }
}