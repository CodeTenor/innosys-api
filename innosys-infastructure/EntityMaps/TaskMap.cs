using innosys_domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace innosys_infastructure.EntityMaps
{
    public class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable(Tables.Task);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                   .IsRequired(true);

            builder.Property(x => x.Status)
                   .IsRequired(true);

            builder.Property(x => x.CompletedDate)
                   .IsRequired(false);

            builder.Property(x => x.CreatedDate)
                   .IsRequired(true);

            builder.Property(x => x.ModifiedDate)
                   .IsRequired(true);

            builder.HasOne<Activity>(x => x.Activity)
                 .WithMany(x => x.Tasks)
                 .IsRequired(true)
                 .HasForeignKey("ActivityId");
        }
    }
}
