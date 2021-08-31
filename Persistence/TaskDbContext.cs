using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence
{
    public class TaskDbContext:DbContext,ITaskDbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }


        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StatusConfiguration());
            builder.ApplyConfiguration(new TaskConfiguration());
            base.OnModelCreating(builder);
        }
    }
}