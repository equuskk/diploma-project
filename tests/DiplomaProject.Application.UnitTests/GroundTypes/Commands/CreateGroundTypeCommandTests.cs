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
            var command = new CreateGroundTypeCommand
            {
                Title = "Title"
            };
            var handler = new CreateGroundTypeCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(3);
        }
    }
}