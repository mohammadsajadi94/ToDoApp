using MediatR;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.ToDoItems.Queries
{
    public class GetToDoItemByIdQuery : IRequest<ToDoItem>
    {
        public Guid Id { get; set; }
    }
}
