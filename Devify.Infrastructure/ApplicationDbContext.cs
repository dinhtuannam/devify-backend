using Devify.Entity;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=ADMIN\\SQLEXPRESS;Database=dbDevify;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true;");
    }
}
