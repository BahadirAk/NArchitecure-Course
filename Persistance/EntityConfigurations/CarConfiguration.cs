using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(t => t.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(t => t.CarState).HasColumnName("State").IsRequired();
        builder.Property(t => t.ModelYear).HasColumnName("ModelYear").IsRequired();

        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(t => t.Model);

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}