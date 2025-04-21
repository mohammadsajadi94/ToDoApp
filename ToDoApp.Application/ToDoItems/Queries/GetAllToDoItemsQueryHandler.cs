using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.ToDoItems.Queries
{
    public class GetAllToDoItemsQueryHandler : IRequestHandler<GetAllToDoItemsQuery, List<ToDoItem>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllToDoItemsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItem>> Handle(GetAllToDoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _context.ToDoItems.ToListAsync(cancellationToken);
        }
    }
}
