using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.StationsData.Queries;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.StationsData.Queries
{
    public class GetDataFromStationByIdQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnStationData()
        {
            var command = new GetDataFromStationByIdQuery
            {
                StationId = 1
            };
            var handler = new GetDataFromStationByIdQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().HaveCount(1);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseStationIdIsIncorrect()
        {
            var command = new GetDataFromStationByIdQuery
            {
                StationId = -1
            };
            var handler = new GetDataFromStationByIdQueryHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}