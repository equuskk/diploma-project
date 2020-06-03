using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.SeaweedTypes.Queries;
using FluentAssertions;
using Xunit;

namespace DiplomaProject.Application.UnitTests.SeaweedTypes.Queries
{
    public class GetAllSeaweedTypesQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnSeaweedTypes()
        {
            var command = new GetAllSeaweedTypesQuery();
            var handler = new GetAllSeaweedTypesQueryHandler(ApplicationContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().HaveCount(2);
        }
    }
}