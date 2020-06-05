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
            const string title = "Title";
            const string description = "Description";
            var command = new CreateSectorCommand
            {
                Title = title,
                Description = description
            };
            var handler = new CreateSectorCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(3);
            result.Title.Should().Be(title);
            result.Description.Should().Be(description);
        }
    }
}