using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
            => base.SaveChangesAsync(cancellationToken);
    }
}
