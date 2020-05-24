using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Sectors.Queries;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Sectors.Queries
{
    public class GetAllSectorsQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnSectors()
        {
            var command = new GetAllSectorsQuery();
            var handler = new GetAllSectorsQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);
            var first = result.First();

            result.Should().HaveCount(1);
            first.Id.Should().Be(1);
            first.Title.Should().Be("Title");
        }
    }
}