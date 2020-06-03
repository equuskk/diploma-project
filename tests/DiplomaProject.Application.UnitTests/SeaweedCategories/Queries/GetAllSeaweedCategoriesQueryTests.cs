using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.SeaweedCategories.Queries;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.SeaweedCategories.Queries
{
    public class GetAllSeaweedCategoriesQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnSeaweedCategories()
        {
            var command = new GetAllSeaweedCategoriesQuery();
            var handler = new GetAllSeaweedCategoriesQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().HaveCount(2);
        }
    }
}