using MediatR;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.ToDoItems.Queries
{
    public class GetToDoItemByIdQueryHandler : IRequestHandler<GetToDoItemByIdQuery, ToDoItem>
    {
        private readonly IApplicationDbContext _context;

        public GetToDoItemByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem> Handle(GetToDoItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.ToDoItems.FindAsync(request.Id);
        }
    }
}
