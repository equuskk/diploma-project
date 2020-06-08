using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Seaweeds.Commands;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Seaweeds.Commands
{
    public class DeleteSeaweedCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteLitoral()
        {
            var command = new DeleteSeaweedCommand
            {
                SeaweedId = 1
            };
            var handler = new DeleteSeaweedCommandHandler(ApplicationContext);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseIdIsIncorrect()
        {
            var command = new DeleteSeaweedCommand
            {
                SeaweedId = -1
            };
            var handler = new DeleteSeaweedCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}