using MediatR;

namespace ToDoApp.Application.ToDoItems.Commands
{
    public class CreateToDoItemCommand : IRequest<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
