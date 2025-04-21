using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.ToDoItems.Queries;
using ToDoApp.Domain.Entities;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Tests
{
    public class GetToDoItemByIdTests
    {
        [Fact]
        public async Task ShouldReturnToDoItemById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new ApplicationDbContext(options);
            var item = new ToDoItem { Id = Guid.NewGuid(), Title = "Test1", Description = "Desc1", IsCompleted = false };
            context.ToDoItems.Add(item);
            await context.SaveChangesAsync(CancellationToken.None);

            var handler = new GetToDoItemByIdQueryHandler(context);
            var query = new GetToDoItemByIdQuery { Id = item.Id };
            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(item.Id, result.Id);
        }
    }
}
