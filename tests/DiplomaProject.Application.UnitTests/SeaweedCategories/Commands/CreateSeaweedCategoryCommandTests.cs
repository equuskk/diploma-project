using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.SeaweedCategories.Command;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.SeaweedCategories.Commands
{
    public class CreateSeaweedCategoryCommandTests : TestBase
    {
        [Fact]
        public async Task ShouldCreateSeaweedCategory()
        {
            var command = new CreateSeaweedCategoryCommand
            {
                Title = "Title"
            };
            var handler = new CreateSeaweedCategoryCommandHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(3);
        }
    }
}