namespace SizingCalculator.Persistence.Configurations;

public class DataTypeConfiguration : IEntityTypeConfiguration<DataType>
{
    public void Configure(EntityTypeBuilder<DataType> builder)
    {
        builder.ToTable("data_type");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Title);
        builder.Property(entity => entity.Size);
    }
}
