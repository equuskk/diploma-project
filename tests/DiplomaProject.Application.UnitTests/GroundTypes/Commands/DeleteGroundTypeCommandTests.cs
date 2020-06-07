using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.GroundTypes.Command;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.GroundTypes.Commands
{
    public class DeleteGroundTypeCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteGroundType()
        {
            var command = new DeleteGroundTypeCommand
            {
                Id = 1
            };
            var handler = new DeleteGroundTypeCommandHandler(ApplicationContext);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseIdIsIncorrect()
        {
            var command = new DeleteGroundTypeCommand
            {
                Id = -1
            };
            var handler = new DeleteGroundTypeCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}