using innosys_domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace innosys_infastructure.EntityMaps
{
    public class ActivityMap : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable(Tables.Activity);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ActivityId)
                   .IsRequired(true);

            builder.Property(x => x.Description)
                   .IsRequired(true);

            builder.Property(x => x.Client)
                   .IsRequired(true);

            builder.Property(x => x.StartDate)
                   .IsRequired(true);

            builder.Property(x => x.DueDate)
                   .IsRequired(true);

            builder.Property(x => x.Duration)
                   .IsRequired(true);

            builder.Property(x => x.CreatedDate)
                   .IsRequired(true);

            builder.Property(x => x.ModifiedDate)
                   .IsRequired(true);
        }
    }
}
