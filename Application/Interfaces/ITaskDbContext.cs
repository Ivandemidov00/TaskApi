using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Task;

namespace Application.Interfaces
{
    public interface ITaskDbContext
    {
        DbSet<Task> Tasks { get; set; }
        DbSet<Status> Statuses { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}