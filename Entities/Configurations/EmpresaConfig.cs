using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SucursalLab.Entities.Configurations
{
    public class EmpresaConfig
    {
        public void Configure(EntityTypeBuilder<EmpresaEntity> builder)
        {
            builder.Property(e=>e.Name).HasMaxLength(40);
            builder.Property(e=>e.Description).HasMaxLength(150);  
        }
    }
}