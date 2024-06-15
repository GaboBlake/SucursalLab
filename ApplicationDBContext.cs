using Microsoft.EntityFrameworkCore;

namespace SucursalesLab
{
    public class ApplicationDBContext : DbContext

    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SucursalEntity> Sucursales => Set<SucursalEntity>();

    }
}