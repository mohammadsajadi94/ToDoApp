using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.ToDoItems.Commands;
using ToDoApp.Domain.Entities;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Tests
{
    public class UpdateToDoItemTests
    {
        [Fact]
        public async Task ShouldUpdateToDoItem()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new ApplicationDbContext(options);
            var item = new ToDoItem { Id = Guid.NewGuid(), Title = "Test1", Description = "Desc1", IsCompleted = false };
            context.ToDoItems.Add(item);
            await context.SaveChangesAsync(CancellationToken.None);

            var handler = new UpdateToDoItemCommandHandler(context);
            var command = new UpdateToDoItemCommand
            {
                Id = item.Id,
                Title = "Updated Title",
                Description = "Updated Description",
                IsCompleted = true
            };
            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result);
            var updatedItem = await context.ToDoItems.FindAsync(item.Id);
            Assert.Equal("Updated Title", updatedItem?.Title);
        }
    }
}
