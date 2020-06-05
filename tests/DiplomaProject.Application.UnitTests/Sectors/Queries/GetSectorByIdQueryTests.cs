using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Sectors.Queries;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Sectors.Queries
{
    public class GetSectorByIdQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnSectorWithThatId()
        {
            var command = new GetSectorByIdQuery
            {
                SectorId = 1
            };
            var handler = new GetSectorByIdQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(1);
            result.Title.Should().Be("Title #2");
            result.Expeditions.Should().NotBeNull();
            result.Thickets.Should().NotBeNull();
            result.Expeditions.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldThrowNotFoundException()
        {
            var command = new GetSectorByIdQuery
            {
                SectorId = 11111
            };
            var handler = new GetSectorByIdQueryHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}