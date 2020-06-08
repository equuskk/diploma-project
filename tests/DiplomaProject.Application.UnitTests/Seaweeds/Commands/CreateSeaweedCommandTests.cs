using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Seaweeds.Commands;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Seaweeds.Commands
{
    public class CreateSeaweedCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateSeaweed()
        {
            var command = new CreateSeaweedCommand
            {
                Title = "1",
                SeaweedCategoryId = 1,
                SeaweedTypeId = 1
            };
            var handler = new CreateSeaweedCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(3);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseCategoryIsIncorrect()
        {
            var command = new CreateSeaweedCommand
            {
                Title = "1",
                SeaweedCategoryId = -1,
                SeaweedTypeId = 1
            };
            var handler = new CreateSeaweedCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<DbUpdateException>();
        }

        [Fact]
        public async Task ShouldThrowException_BecauseTypeIsIncorrect()
        {
            var command = new CreateSeaweedCommand
            {
                Title = "1",
                SeaweedCategoryId = 1,
                SeaweedTypeId = -1
            };
            var handler = new CreateSeaweedCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            await func.Should().ThrowAsync<DbUpdateException>();
        }
    }
}