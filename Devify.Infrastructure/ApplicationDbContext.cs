using Devify.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Course_Language> Course_Languages { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=ADMIN\\SQLEXPRESS;Database=dbDevify;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Course_Language>().HasKey(x => new { x.CourseId, x.LanguageId });

            builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "2ca8fa08-4a80-4714-a5fb-17b7316fddc4",
                Name = "Admin",
                NormalizedName = "ADMIN".ToUpper()
            },
            new IdentityRole
            {
                Id = "88ac3925-8432-4f60-89e2-96433d08bbcf",
                Name = "Manager",
                NormalizedName = "MANAGER".ToUpper()
            }
            );
            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
               new IdentityUser
               {
                   Id = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                   UserName = "Super Admin",
                   NormalizedUserName = "SUPER ADMIN".ToUpper(),
                   Email = "admin@gmail.com",
                   NormalizedEmail = "ADMIN@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Admin@123")
               }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    UserId = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                    RoleId = "2ca8fa08-4a80-4714-a5fb-17b7316fddc4"
                },
                new IdentityUserRole<string>
                {
                    UserId = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                    RoleId = "88ac3925-8432-4f60-89e2-96433d08bbcf"
                }
            );
        }
    }
}
