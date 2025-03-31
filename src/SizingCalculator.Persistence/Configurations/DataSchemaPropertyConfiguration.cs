namespace SizingCalculator.Persistence.Configurations;

public class DataSchemaPropertyConfiguration : IEntityTypeConfiguration<DataSchemaProperty>
{
    public void Configure(EntityTypeBuilder<DataSchemaProperty> builder)
    {
        builder.ToTable("data_schema_property");

        builder.Property(entity => entity.Title);
        builder.Property(entity => entity.Quantity);
        builder.HasOne(entity => entity.DataType).WithMany();
    }
}
