using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.StationsData.Commands;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.StationsData.Commands
{
    public class CreateStationDataCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateStationData()
        {
            var command = new CreateStationDataCommand
            {
                Date = new DateTimeOffset(2019, 01, 01, 01, 01, 01, TimeSpan.Zero),
                Density = 10,
                Depth = 0.2f,
                StationId = 1,
                Temperature = -7.3f
            };
            var handler = new CreateStationDataCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(2);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseStationIdIsIncorrect()
        {
            var command = new CreateStationDataCommand
            {
                Date = new DateTimeOffset(2019, 01, 01, 01, 01, 01, TimeSpan.Zero),
                Density = 10,
                Depth = 0.2f,
                StationId = -1,
                Temperature = -7.3f
            };
            var handler = new CreateStationDataCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}