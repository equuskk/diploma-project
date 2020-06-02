using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Expeditions.Queries;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Expedition.Queries
{
    public class GetAllExpeditionsQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnExpeditions()
        {
            var command = new GetAllExpeditionsQuery();
            var handler = new GetAllExpeditionsQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().HaveCount(1);
            result.First().Should().NotBeNull();
        }
    }
}