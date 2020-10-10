using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.GroundTypes.Command;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.GroundTypes.Commands
{
    public class CreateGroundTypeCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateGroundType()
        {
            const string title = "Title";
            var command = new CreateGroundTypeCommand
            {
                Title = title
            };
            var handler = new CreateGroundTypeCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(3);
            result.Title.Should().Be(title);
        }
    }
}