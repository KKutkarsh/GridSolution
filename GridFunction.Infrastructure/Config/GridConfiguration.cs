using GridFunction.Infrastructure.Helpers;
using GridFunctions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GridFunction.Infrastructure.Config
{
    public class GridConfiguration : IEntityTypeConfiguration<Grid>
    {
        public void Configure(EntityTypeBuilder<Grid> builder)
        {
            builder.Property(x => x.Id).HasColumnName("GridId")
                .HasColumnType(Constants.intType)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.GridName).HasColumnType(Constants.varchar250);

            builder.HasMany(x => x.GridRegions)
                .WithOne(x => x.Grid)
                .HasForeignKey(x => x.GridId);
            builder.HasMany(x => x.GridDetails)
                .WithOne(x => x.Grid)
                .HasForeignKey(x => x.GridId);

            builder.HasData(
                new Grid { Id = 1, GridName = "Grid1" },
                new Grid { Id = 2, GridName = "Grid2" },
                new Grid { Id = 3, GridName = "Grid3" }
                );
        }
    }
}
