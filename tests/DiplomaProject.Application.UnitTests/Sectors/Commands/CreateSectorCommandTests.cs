using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Sectors.Commands;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Sectors.Commands
{
    public class CreateSectorCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateSector()
        {
            var command = new CreateSectorCommand
            {
                Square = 123,
                LitoralId = 1
            };
            var handler = new CreateSectorCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(4);
            result.Square.Should().Be(123);
            result.LitoralId.Should().Be(1);
        }
    }
}