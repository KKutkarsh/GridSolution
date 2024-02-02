using GridFunction.Infrastructure.Helpers;
using GridFunctions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GridFunction.Infrastructure.Config
{
    public class GridRegionConfiguration : IEntityTypeConfiguration<GridRegion>
    {
        public void Configure(EntityTypeBuilder<GridRegion> builder)
        {
            builder.Property(x => x.Id).HasColumnName("GridRegionId")
                .HasColumnType(Constants.intType)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.RegionName).HasColumnType(Constants.varchar100);

            builder.HasMany(x => x.GridNodes)
                .WithOne(x => x.Region)
                .HasForeignKey(x => x.GridRegionId);

            builder.HasData(
                new GridRegion { Id = 1, GridId = 1, RegionName = "Region1" },
                new GridRegion { Id = 2, GridId = 1, RegionName = "Region2" },
                new GridRegion { Id = 3, GridId = 1, RegionName = "Region3" },
                new GridRegion { Id = 4, GridId = 2, RegionName = "Region1" },
                new GridRegion { Id = 5, GridId = 2, RegionName = "Region2" },
                new GridRegion { Id = 6, GridId = 2, RegionName = "Region3" },
                new GridRegion { Id = 7, GridId = 3, RegionName = "Region1" },
                new GridRegion { Id = 8, GridId = 3, RegionName = "Region2" },
                new GridRegion { Id = 9, GridId = 3, RegionName = "Region3" }
                );
        }
    }
}
