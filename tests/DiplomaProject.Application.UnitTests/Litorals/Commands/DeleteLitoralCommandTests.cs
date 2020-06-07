using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Litorals.Command;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Litorals.Commands
{
    public class DeleteLitoralCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteLitoral()
        {
            var command = new DeleteLitoralCommand
            {
                Id = 1
            };
            var handler = new DeleteLitoralCommandHandler(ApplicationContext);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseIdIsIncorrect()
        {
            var command = new DeleteLitoralCommand
            {
                Id = -1
            };
            var handler = new DeleteLitoralCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}