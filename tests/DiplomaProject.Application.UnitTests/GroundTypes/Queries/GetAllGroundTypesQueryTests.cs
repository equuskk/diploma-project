using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.GroundTypes.Queries;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.GroundTypes.Queries
{
    public class GetAllGroundTypesQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnGroundTypes()
        {
            var command = new GetAllGroundTypesQuery();
            var handler = new GetAllGroundTypesQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().HaveCount(2);
        }
    }
}