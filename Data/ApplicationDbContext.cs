using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rukomet.Models;

namespace PINProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Rukomet.Models.Klub> Klub { get; set; }
        public DbSet<Rukomet.Models.Igrac> Igrac { get; set; }
    }
}