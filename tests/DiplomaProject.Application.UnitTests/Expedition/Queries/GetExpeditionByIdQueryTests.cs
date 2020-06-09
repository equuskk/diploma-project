using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.Application.Expeditions.Queries;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace DiplomaProject.Application.UnitTests.Expedition.Queries
{
    public class GetExpeditionByIdQueryTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnExpedition()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(a => a.GetRolesAsync(It.IsAny<Employee>()))
               .ReturnsAsync(new List<string> { "Роль1" });
            var command = new GetExpeditionByIdQuery
            {
                Id = 1
            };
            var handler = new GetExpeditionByIdQueryHandler(ApplicationContext, mgr.Object);

            var result = await handler.Handle(command, CancellationToken.None);
            result.Employees.Should().NotBeNull();
            result.Sectors.Should().NotBeNull();
            result.Thickets.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldThrowException()
        {
            var store = new Mock<IUserStore<Employee>>();
            var mgr = new Mock<UserManager<Employee>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Setup(a => a.GetRolesAsync(It.IsAny<Employee>()))
               .Returns(Task.FromResult<IList<string>>(new List<string> { "Роль1" }));
            var command = new GetExpeditionByIdQuery
            {
                Id = -1
            };
            var handler = new GetExpeditionByIdQueryHandler(ApplicationContext, mgr.Object);

            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);
            await func.Should().ThrowAsync<NotFoundException>();
        }
    }
}