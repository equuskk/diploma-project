using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.SeaweedCategories.Command;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.SeaweedCategories.Commands
{
    public class DeleteSeaweedCategoryCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldDeleteSeaweedCategory()
        {
            var command = new DeleteSeaweedCategoryCommand
            {
                Id = 1
            };
            var handler = new DeleteSeaweedCategoryCommandHandler(ApplicationContext);

            _ = await handler.Handle(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldThrowException_BecauseIdIsIncorrect()
        {
            var command = new DeleteSeaweedCategoryCommand
            {
                Id = -1
            };
            var handler = new DeleteSeaweedCategoryCommandHandler(ApplicationContext);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}