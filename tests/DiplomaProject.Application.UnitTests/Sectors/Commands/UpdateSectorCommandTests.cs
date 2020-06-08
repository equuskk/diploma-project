using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Sectors.Commands;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Sectors.Commands
{
    public class UpdateSectorCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldThrowException()
        {
            var command = new UpdateSectorCommand
            {
                SectorId = -1,
                Title = "1",
                Description = "1"
            };
            var handler = new UpdateSectorCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task ShouldUpdateSector()
        {
            const string title = "Title234";
            const string description = "Description234";
            var command = new UpdateSectorCommand
            {
                SectorId = 1,
                Title = title,
                Description = description
            };
            var handler = new UpdateSectorCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(1);
            result.Title.Should().Be(title);
            result.Description.Should().Be(description);
        }
    }
}