using MediatR;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.ToDoItems.Queries
{
    public class GetAllToDoItemsQuery : IRequest<List<ToDoItem>> { }
}
