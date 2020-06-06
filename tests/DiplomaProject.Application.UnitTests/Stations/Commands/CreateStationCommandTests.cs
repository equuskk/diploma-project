using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Stations.Commands;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Stations.Commands
{
    public class CreateStationCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateStation()
        {
            var command = new CreateStationCommand
            {
                Location = new Point(1.1, 1.1),
                SectorId = 1,
                Title = "Title"
            };
            var handler = new CreateStationCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(2);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseThicketIdIsIncorrect()
        {
            var command = new CreateStationCommand
            {
                Location = new Point(1.1, 1.1),
                SectorId = -1,
                Title = "Title"
            };
            var handler = new CreateStationCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<DbUpdateException>();
        }
    }
}