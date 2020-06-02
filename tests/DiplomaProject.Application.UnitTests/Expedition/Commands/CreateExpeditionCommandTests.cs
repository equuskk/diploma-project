using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Expeditions.Commands;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Expedition.Commands
{
    public class CreateExpeditionCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateExpedition()
        {
            var fromDate = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero);
            var toDate = fromDate.AddMonths(1);
            var command = new CreateExpeditionCommand
            {
                FromDate = fromDate,
                ToDate = toDate
            };
            var handler = new CreateExpeditionCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);
            result.Id.Should().Be(2);
            result.FromDate.Should().Be(fromDate);
            result.ToDate.Should().Be(toDate);
        }

        [Fact]
        public async Task ShouldThrowException()
        {
            var fromDate = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero);
            var toDate = fromDate.AddMonths(-1);
            var command = new CreateExpeditionCommand
            {
                FromDate = fromDate,
                ToDate = toDate
            };
            var handler = new CreateExpeditionCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<ArgumentException>();
        }
    }
}