using MediatR;

namespace ToDoApp.Application.ToDoItems.Commands
{
    public class DeleteToDoItemCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
