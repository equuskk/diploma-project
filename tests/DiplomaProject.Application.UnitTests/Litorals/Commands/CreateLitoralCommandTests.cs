using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Litorals.Command;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Litorals.Commands
{
    public class CreateLitoralCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateLitoral()
        {
            var command = new CreateLitoralCommand
            {
                Title = "Title"
            };
            var handler = new CreateLitoralCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(5);
        }
    }
}