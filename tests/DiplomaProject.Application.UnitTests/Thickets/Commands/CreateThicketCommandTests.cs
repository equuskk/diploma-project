using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Thickets.Commands;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Thickets.Commands
{
    public class CreateThicketCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateThicket()
        {
            var command = new CreateThicketCommand
            {
                Location = new Point(1.1, 1.1),
                Date = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero),
                Length = 10,
                WeightPerMeter = 5,
                Width = 10,
                LitoralId = 1,
                SeaweedId = 1,
                GroundTypeId = 1,
                SectorId = 1
            };
            var handler = new CreateThicketCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(2);
            result.Stock.Should().Be(500);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseGroundTypeIdIsIncorrect()
        {
            var command = new CreateThicketCommand
            {
                Location = new Point(1.1, 1.1),
                Date = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero),
                Length = 100,
                WeightPerMeter = 12,
                Width = 10,
                LitoralId = 1,
                SeaweedId = 1,
                GroundTypeId = -1,
                SectorId = 1
            };

            var handler = new CreateThicketCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<DbUpdateException>("Некорректный ID типа грунта");
        }

        [Fact]
        public async Task ShouldThrowException_BecauseLitoralIdIsIncorrect()
        {
            var command = new CreateThicketCommand
            {
                Location = new Point(1.1, 1.1),
                Date = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero),
                Length = 100,
                WeightPerMeter = 12,
                Width = 10,
                LitoralId = -1,
                SeaweedId = 1,
                GroundTypeId = 1,
                SectorId = 1
            };

            var handler = new CreateThicketCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<DbUpdateException>("Некорректный ID литорали");
        }

        [Fact]
        public async Task ShouldThrowException_BecauseSeaweedIdIsIncorrect()
        {
            var command = new CreateThicketCommand
            {
                Location = new Point(1.1, 1.1),
                Date = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero),
                Length = 100,
                WeightPerMeter = 12,
                Width = 10,
                LitoralId = 1,
                SeaweedId = -1,
                GroundTypeId = 1,
                SectorId = 1
            };

            var handler = new CreateThicketCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<DbUpdateException>("Некорректный ID водоросли");
        }

        [Fact]
        public async Task ShouldThrowException_BecauseSectorIdIsIncorrect()
        {
            var command = new CreateThicketCommand
            {
                Location = new Point(1.1, 1.1),
                Date = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero),
                Length = 100,
                WeightPerMeter = 12,
                Width = 10,
                LitoralId = 1,
                SeaweedId = 1,
                GroundTypeId = 1,
                SectorId = -1
            };

            var handler = new CreateThicketCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<DbUpdateException>("Некорректный ID сектора");
        }
    }
}