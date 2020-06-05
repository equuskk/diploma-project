using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Expeditions.Commands;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Expedition.Commands
{
    public class AddEmployeesToExpeditionCommandTest : TestBase
    {
        [Fact]
        public async Task ShouldAddSectorsToExpedition()
        {
            var command = new AddEmployeesToExpeditionCommand
            {
                ExpeditionId = 1,
                UserIds = new[] { UserId }
            };
            var handler = new AddEmployeesToExpeditionCommandHandler(ApplicationContext);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseExpeditionIdIsIncorrect()
        {
            var command = new AddEmployeesToExpeditionCommand
            {
                ExpeditionId = -1,
                UserIds = new[] { UserId }
            };
            var handler = new AddEmployeesToExpeditionCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<DbUpdateException>();
        }

        [Fact]
        public async Task ShouldThrowException_BecauseSectorIdsAreIncorrect()
        {
            var command = new AddEmployeesToExpeditionCommand
            {
                ExpeditionId = 1,
                UserIds = new[] { Guid.NewGuid().ToString() }
            };
            var handler = new AddEmployeesToExpeditionCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<DbUpdateException>();
        }
    }
}