using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Stations.Commands;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Stations.Commands
{
    public class DeleteStationCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteStation()
        {
            var command = new DeleteStationCommand
            {
                Id = 1
            };
            var handler = new DeleteStationCommandHandler(ApplicationContext);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseIdIsIncorrect()
        {
            var command = new DeleteStationCommand
            {
                Id = -1
            };
            var handler = new DeleteStationCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}