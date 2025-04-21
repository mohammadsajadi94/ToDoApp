using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ToDoItem> ToDoItems { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
