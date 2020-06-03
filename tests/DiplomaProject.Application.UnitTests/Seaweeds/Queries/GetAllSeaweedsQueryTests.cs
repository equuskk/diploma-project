using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Seaweeds.Queries;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Seaweeds.Queries
{
    public class GetAllSeaweedsQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnSeaweeds()
        {
            var command = new GetAllSeaweedsQuery();
            var handler = new GetAllSeaweedsQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);
            var first = result.First();

            result.Should().HaveCount(2);
            first.Category.Should().NotBeNull();
            first.Type.Should().NotBeNull();
        }
    }
}