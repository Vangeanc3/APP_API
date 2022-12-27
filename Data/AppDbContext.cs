using APP_API.Models;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts)
            : base(opts)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = default!;

    }
}