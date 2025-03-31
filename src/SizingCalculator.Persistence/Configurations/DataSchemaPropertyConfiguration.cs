namespace SizingCalculator.Persistence.Configurations;

public class DataSchemaPropertyConfiguration : IEntityTypeConfiguration<DataSchemaProperty>
{
    public void Configure(EntityTypeBuilder<DataSchemaProperty> builder)
    {
        builder.ToTable("data_schema_property");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Title);
        builder.Property(entity => entity.Quantity);
        builder.Ignore(entity => entity.TotalSize);
        builder.Ignore(entity => entity.SelectedDataTypeId);

        builder.HasOne(entity => entity.DataType).WithMany();
    }
}
