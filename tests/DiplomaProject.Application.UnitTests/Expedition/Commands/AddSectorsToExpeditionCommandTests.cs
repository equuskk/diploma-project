using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Expeditions.Commands;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Expedition.Commands
{
    public class AddSectorsToExpeditionCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldAddSectorsToExpedition()
        {
            var command = new AddSectorsToExpeditionCommand
            {
                ExpeditionId = 1,
                SectorIds = new[] { 1, 2 }
            };
            var handler = new AddSectorsToExpeditionCommandHandler(ApplicationContext);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseExpeditionIdIsIncorrect()
        {
            var command = new AddSectorsToExpeditionCommand
            {
                ExpeditionId = -1,
                SectorIds = new[] { 1, 2 }
            };
            var handler = new AddSectorsToExpeditionCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<DbUpdateException>();
        }

        [Fact]
        public async Task ShouldThrowException_BecauseSectorIdsAreIncorrect()
        {
            var command = new AddSectorsToExpeditionCommand
            {
                ExpeditionId = 1,
                SectorIds = new[] { -1, -2 }
            };
            var handler = new AddSectorsToExpeditionCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<DbUpdateException>();
        }
    }
}