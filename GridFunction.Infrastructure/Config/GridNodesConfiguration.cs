using GridFunction.Infrastructure.Helpers;
using GridFunctions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GridFunction.Infrastructure.Config
{
    public class GridNodesConfiguration : IEntityTypeConfiguration<GridNode>
    {
        public void Configure(EntityTypeBuilder<GridNode> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnName("GridNodeId")
                .HasColumnType(Constants.intType)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.NodeName).HasColumnType(Constants.varchar100);

            builder.HasMany(x => x.Measures)
                .WithOne(x => x.GridNode)
                .HasForeignKey(x => x.GridNodeId);

            builder.HasData(
                new GridNode { Id = 1, GridRegionId = 1, NodeName = "Node1" },
                new GridNode { Id = 2, GridRegionId = 1, NodeName = "Node2" },
                new GridNode { Id = 3, GridRegionId = 1, NodeName = "Node3" },
                new GridNode { Id = 4, GridRegionId = 2, NodeName = "Node1" },
                new GridNode { Id = 5, GridRegionId = 2, NodeName = "Node2" },
                new GridNode { Id = 6, GridRegionId = 2, NodeName = "Node3" },
                new GridNode { Id = 7, GridRegionId = 3, NodeName = "Node1" },
                new GridNode { Id = 8, GridRegionId = 3, NodeName = "Node2" },
                new GridNode { Id = 9, GridRegionId = 3, NodeName = "Node3" }
                );

        }
    }
}
