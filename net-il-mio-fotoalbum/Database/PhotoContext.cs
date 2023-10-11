using net_il_mio_fotoalbum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace net_il_mio_fotoalbum.Database
{
    public class PhotoContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Photo;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
