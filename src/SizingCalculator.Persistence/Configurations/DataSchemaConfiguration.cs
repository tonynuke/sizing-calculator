namespace SizingCalculator.Persistence.Configurations;

public class DataSchemaConfiguration : IEntityTypeConfiguration<DataSchema>
{
    public void Configure(EntityTypeBuilder<DataSchema> builder)
    {
        builder.ToTable("data_schema");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Title);
        builder
            .HasMany(entity => entity.Properties)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(entity => entity.SizingOptions).HasColumnType("jsonb");
    }
}
