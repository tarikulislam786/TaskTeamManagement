using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Tms.Domain.Entities;

namespace Tms.Application.Common.Interfaces
{
    public interface ITmsDbContext
    {
        DbSet<ApplicationUser> Users { get; }
        DbSet<TaskItem> Tasks { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
