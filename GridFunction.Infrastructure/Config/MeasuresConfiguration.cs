using GridFunction.Infrastructure.Helpers;
using GridFunctions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GridFunction.Infrastructure.Config
{
    public class MeasuresConfiguration : IEntityTypeConfiguration<Measure>
    {
        public void Configure(EntityTypeBuilder<Measure> builder)
        {
            builder.Property(x => x.Id).HasColumnName("MeasureId")
                .HasColumnType(Constants.intType)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Measurement).HasColumnType(Constants.intType);
            builder.Property(x=>x.Timespan).HasColumnType(Constants.dateTime).IsRequired();
            builder.Property(x=>x.CollectedAt).HasColumnType(Constants.dateTime).IsRequired();
        }
    }
}
