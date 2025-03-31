using System.Reflection;

namespace SizingCalculator.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<DataType> DataTypes { get; internal set; }
    public DbSet<DataSchema> DataSchemas { get; internal set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = Assembly.GetExecutingAssembly();
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        //modelBuilder.HasDefaultSchema
    }
}
