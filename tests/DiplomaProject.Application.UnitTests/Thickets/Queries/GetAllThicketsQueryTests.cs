using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Thickets.Queries;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Thickets.Queries
{
    public class GetAllThicketsQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnThickets()
        {
            var command = new GetAllThicketsQuery();
            var handler = new GetAllThicketsQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);
            var first = result.First();

            result.Should().HaveCount(1);
            first.Litoral.Should().NotBeNull();
            first.Sector.Should().NotBeNull();
            first.GroundType.Should().NotBeNull();
            first.Seaweed.Should().NotBeNull();
        }
    }
}