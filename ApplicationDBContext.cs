using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace SucursalesLab
{
    public class ApplicationDBContext : DbContext

    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<SucursalEntity> Sucursales => Set<SucursalEntity>();

    }

    

}