using MediatR;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.ToDoItems.Commands
{
    public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateToDoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var item = new ToDoItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false
            };

            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync(cancellationToken);

            return item.Id;
        }
    }
}
