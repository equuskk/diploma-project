using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.SeaweedTypes.Command;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.SeaweedTypes.Commands
{
    public class CreateSeaweedTypeCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateSeaweedType()
        {
            var command = new CreateSeaweedTypeCommand
            {
                Title = "Title"
            };
            var handler = new CreateSeaweedTypeCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(3);
        }
    }
}