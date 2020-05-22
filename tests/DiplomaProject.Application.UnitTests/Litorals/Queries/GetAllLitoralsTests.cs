using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Litorals.Queries;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Litorals.Queries
{
    public class GetAllLitoralsTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnLitorals()
        {
            var command = new GetAllLitorals();
            var handler = new GetAllLitoralsHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);
            var first = result.First();

            result.Should().HaveCount(4);
            first.Title.Should().Be("Скальная литораль");
        }
    }
}