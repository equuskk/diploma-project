using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Sectors.Commands;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Sectors.Commands
{
    public class DeleteSectorCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteSector()
        {
            var command = new DeleteSectorCommand
            {
                SectorId = 1
            };
            var handler = new DeleteSectorCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().NotThrowAsync();
        }

        [Fact]
        public async Task ShouldThrowException()
        {
            var command = new DeleteSectorCommand
            {
                SectorId = 123456
            };
            var handler = new DeleteSectorCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}