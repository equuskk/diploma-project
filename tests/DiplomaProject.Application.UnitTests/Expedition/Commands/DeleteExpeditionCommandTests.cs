using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Expeditions.Commands;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using MediatR;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Expedition.Commands
{
    public class DeleteExpeditionCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteExpedition()
        {
            var command = new DeleteExpeditionCommand
            {
                Id = 1
            };
            var handler = new DeleteExpeditionCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);
            result.Should().Be(Unit.Value);
        }

        [Fact]
        public async Task ShouldThrowException()
        {
            var command = new DeleteExpeditionCommand
            {
                Id = -1
            };
            var handler = new DeleteExpeditionCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}