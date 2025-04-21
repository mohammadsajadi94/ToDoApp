using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.ToDoItems.Queries;
using ToDoApp.Domain.Entities;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Tests
{
    public class GetAllToDoItemsTests
    {
        [Fact]
        public async Task ShouldReturnAllToDoItems()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new ApplicationDbContext(options);
            context.ToDoItems.Add(new ToDoItem { Id = Guid.NewGuid(), Title = "Test1", Description = "Desc1", IsCompleted = false });
            context.ToDoItems.Add(new ToDoItem { Id = Guid.NewGuid(), Title = "Test2", Description = "Desc2", IsCompleted = true });
            await context.SaveChangesAsync(CancellationToken.None);

            var handler = new GetAllToDoItemsQueryHandler(context);
            var result = await handler.Handle(new GetAllToDoItemsQuery(), CancellationToken.None);

            Assert.Equal(2, result.Count);
        }
    }
}
