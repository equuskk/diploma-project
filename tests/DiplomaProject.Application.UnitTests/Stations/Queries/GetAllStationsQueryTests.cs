using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Stations.Queries;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Stations.Queries
{
    public class GetAllStationsQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnStations()
        {
            var command = new GetAllStationsQuery();
            var handler = new GetAllStationsQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);
            var first = result.First();

            result.Should().HaveCount(1);
            first.Sector.Should().NotBeNull();
        }
    }
}