using GridFunctions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace GridFunction.Infrastructure.DataContexts
{
    public class GridContext : DbContext
    {
        private readonly string _connectionString = string.Empty;
        public GridContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        // for unit Testing

        public GridContext()
        {
            
        }

        public GridContext(DbContextOptions<GridContext> options) : base(options) { }
        public virtual DbSet<Grid> Grids { get; set; }
        public virtual DbSet<GridDetail> GridDetails { get; set; }
        public virtual DbSet<GridRegion> GridRegions { get; set; }
        public virtual DbSet<GridNode> GridNodes { get; set; }
        public virtual DbSet<Measure> Measures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, options => options.EnableRetryOnFailure());
                //mostly Db has read operation this will reduce memory consumption and improve performance
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }

        }

        public virtual bool IsEntryDetached(object entity)
        {
            return Entry(entity).State == EntityState.Detached;
        }
        public virtual void SetState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }
    }


    /// <summary>
    /// Explicitly for migration.
    /// Not recomended but db migration is not reading data from Environment.
    /// needs some R&D
    /// </summary>
    public class GridContextFactory : IDesignTimeDbContextFactory<GridContext>
    {
        public GridContext CreateDbContext(string[] args)
        {
            var conString = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=true;Database=GridDb";
            var optionsBuilder = new DbContextOptionsBuilder<GridContext>();
            optionsBuilder.UseSqlServer(conString);

            return new GridContext(optionsBuilder.Options);
        }
    }
}
