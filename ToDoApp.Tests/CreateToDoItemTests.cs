using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.ToDoItems.Commands;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Tests
{
    public class CreateToDoItemTests
    {
        [Fact]
        public async Task ShouldCreateNewToDoItem()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateToDoItemTestDb")
                .Options;

            using var context = new ApplicationDbContext(options);
            var handler = new CreateToDoItemCommandHandler(context);

            var command = new CreateToDoItemCommand
            {
                Title = "Test Title",
                Description = "Test Description"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            var item = await context.ToDoItems.FirstOrDefaultAsync(x => x.Id == result);
            Assert.NotNull(item);
            Assert.Equal("Test Title", item.Title);
            Assert.Equal("Test Description", item.Description);
            Assert.False(item.IsCompleted);
        }
    }
}
