using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Application.ToDoItems.Commands
{
    public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteToDoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (item == null)
            {
                throw new Exception("Item not found");
            }

            _context.ToDoItems.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
