using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.StationsData.Commands;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.StationsData.Commands
{
    public class DeleteStationDataCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteStationData()
        {
            var command = new DeleteStationDataCommand
            {
                StationDataId = 1
            };
            var handler = new DeleteStationDataCommandHandler(ApplicationContext);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseIdIsIncorrect()
        {
            var command = new DeleteStationDataCommand
            {
                StationDataId = -1
            };
            var handler = new DeleteStationDataCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}