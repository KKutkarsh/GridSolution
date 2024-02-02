using GridFunction.Infrastructure.Helpers;
using GridFunctions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GridFunction.Infrastructure.Config
{
    public class GridDetailConfiguration : IEntityTypeConfiguration<GridDetail>
    {
        public void Configure(EntityTypeBuilder<GridDetail> builder)
        {
            builder.Property(x => x.Id).HasColumnName("GridDetailId")
                .HasColumnType(Constants.intType)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Name).HasColumnType(Constants.varchar100);
            builder.Property(x => x.OtherDetails).HasColumnType(Constants.varchar250);
        }
    }
}
