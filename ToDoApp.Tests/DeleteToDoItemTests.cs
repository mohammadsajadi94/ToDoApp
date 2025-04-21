using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.ToDoItems.Commands;
using ToDoApp.Domain.Entities;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Tests
{
    public class DeleteToDoItemTests
    {
        [Fact]
        public async Task ShouldDeleteToDoItem()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new ApplicationDbContext(options);
            var item = new ToDoItem { Id = Guid.NewGuid(), Title = "Test1", Description = "Desc1", IsCompleted = false };
            context.ToDoItems.Add(item);
            await context.SaveChangesAsync(CancellationToken.None);

            var handler = new DeleteToDoItemCommandHandler(context);
            var command = new DeleteToDoItemCommand { Id = item.Id };
            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result);
            var deletedItem = await context.ToDoItems.FindAsync(item.Id);
            Assert.Null(deletedItem);
        }
    }
}
