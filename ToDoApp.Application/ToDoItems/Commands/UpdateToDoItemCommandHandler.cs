using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Application.ToDoItems.Commands
{
    public class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateToDoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (item == null)
            {
                throw new Exception("Item not found");
            }

            item.Title = request.Title;
            item.Description = request.Description;
            item.IsCompleted = request.IsCompleted;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
