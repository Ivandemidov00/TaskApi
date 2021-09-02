using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TaskConfiguration:IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(task => task.ID);
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(40);
            builder.HasOne(c => c.Status).WithMany(e => e.Tasks).OnDelete(DeleteBehavior.Cascade).IsRequired();
        }
    }
}