using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Thickets.Commands;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Thickets.Commands
{
    public class DeleteThicketCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteThicket()
        {
            var command = new DeleteThicketCommand
            {
                Id = 1
            };
            var handler = new DeleteThicketCommandHandler(ApplicationContext);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowNotFoundException()
        {
            var command = new DeleteThicketCommand
            {
                Id = -1
            };
            var handler = new DeleteThicketCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}