using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SucursalConfig : IEntityTypeConfiguration<SucursalEntity>
{
    public void Configure(EntityTypeBuilder<SucursalEntity> builder)
    {
        builder.Property(s=>s.Name).HasMaxLength(25);
    }
}