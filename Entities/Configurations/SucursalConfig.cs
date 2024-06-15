using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SucursalConfig : IEntityTypeConfiguration<SucursalEntity>
{
    public void Configure(EntityTypeBuilder<SucursalEntity> builder)
    {
        builder.Property(s=>s.Name).HasMaxLength(25);
        builder.Property(s=>s.Empresa).HasMaxLength(30);
        builder.Property(s=>s.Location).HasMaxLength(50);
        builder.Property(s=>s.Presupuesto).HasPrecision(8,2);

    }
}