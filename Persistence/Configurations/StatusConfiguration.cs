using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class StatusConfiguration:IEntityTypeConfiguration<Status>
    {

        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(status => status.Status_ID);
            builder.HasMany(c => c.Tasks).WithOne(e => e.Status).IsRequired();
        }
    }
}