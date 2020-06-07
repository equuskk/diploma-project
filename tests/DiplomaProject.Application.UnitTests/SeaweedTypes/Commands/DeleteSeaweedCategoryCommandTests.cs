using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.SeaweedTypes.Command;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.SeaweedTypes.Commands
{
    public class DeleteSeaweedTypeCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteSeaweedType()
        {
            var command = new DeleteSeaweedTypeCommand
            {
                Id = 1
            };
            var handler = new DeleteSeaweedTypeCommandHandler(ApplicationContext);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseIdIsIncorrect()
        {
            var command = new DeleteSeaweedTypeCommand
            {
                Id = -1
            };
            var handler = new DeleteSeaweedTypeCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}