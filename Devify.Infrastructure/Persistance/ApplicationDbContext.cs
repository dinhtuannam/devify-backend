using Devify.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Devify.Infrastructure.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Course_Language> Course_Languages { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DetailOrder> DetailOrders { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseLazyLoadingProxies(false).UseSqlServer("Server=Admin-PC\\SQLEXPRESS;Database=dbDevify;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Creator>().HasKey(x => new { x.CreatorId });
            builder.Entity<Course_Language>().HasKey(x => new { x.CourseId, x.LanguageId });
            builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<DetailOrder>().HasKey(x => new { x.OrderId, x.CourseId });

            builder.Entity<DetailOrder>()
                .HasOne(e => e.Order)
                .WithMany(e => e.DetailOrders)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DetailOrder>()
                .HasOne(e => e.Course)
                .WithMany(e => e.DetailOrders)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "2ca8fa08-4a80-4714-a5fb-17b7316fddc4",
                Name = "Admin",
                NormalizedName = "ADMIN".ToUpper()
            },
            new IdentityRole
            {
                Id = "c6de4ab5-2df7-4a6c-9bbd-2e1b68f8ebdd",
                Name = "Creator",
                NormalizedName = "CREATOR".ToUpper()
            },
            new IdentityRole
            {
                Id = "f28ad7f6-6c3d-4f0f-b9a4-60bca4b57bb3",
                Name = "Customer",
                NormalizedName = "CUSTOMER".ToUpper()
            }
            );
            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<ApplicationUser>().HasData(
               // =================== Inser Admin Role =======================
               new ApplicationUser
               {
                   Id = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                   UserName = "SuperAdmin",
                   NormalizedUserName = "SUPERADMIN".ToUpper(),
                   Email = "admin@gmail.com",
                   NormalizedEmail = "ADMIN@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Nam@123")
               },
               new ApplicationUser
               {
                   Id = "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                   UserName = "SuperManager",
                   NormalizedUserName = "SUPERMANAGER".ToUpper(),
                   Email = "manager@gmail.com",
                   NormalizedEmail = "MANAGER@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Nam@123")
               },

               // =================== Inser Creator Role =======================
               new ApplicationUser
               {
                   Id = "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                   UserName = "DuocDev",
                   NormalizedUserName = "DuocDev".ToUpper(),
                   Email = "duocdev26@gmail.com",
                   NormalizedEmail = "DUOCDEV26@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Nam@123")
               },
               new ApplicationUser
               {
                   Id = "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                   UserName = "ToiDiCodeDao",
                   NormalizedUserName = "TOIDICODEDAO".ToUpper(),
                   Email = "codedao6@gmail.com",
                   NormalizedEmail = "CODEDAO@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Nam@123")
               },
               new ApplicationUser
               {
                   Id = "51274390-9171-49dd-a3e7-6e23fbf327fb",
                   UserName = "HoiDanIT",
                   NormalizedUserName = "HoiDanIT".ToUpper(),
                   Email = "hoidanit@gmail.com",
                   NormalizedEmail = "hoidanit@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Nam@123")
               },
               new ApplicationUser
               {
                   Id = "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                   UserName = "TeduLMS",
                   NormalizedUserName = "TeduLMS".ToUpper(),
                   Email = "tedulms@gmail.com",
                   NormalizedEmail = "tedulms@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Nam@123")
               },

               // =================== Inser Customer Role =======================
               new ApplicationUser
               {
                   Id = "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                   UserName = "Customer",
                   NormalizedUserName = "Customer".ToUpper(),
                   Email = "customer@gmail.com",
                   NormalizedEmail = "CUSTOMER@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Nam@123")
               },
               new ApplicationUser
               {
                   Id = "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                   UserName = "Clone",
                   NormalizedUserName = "Clone".ToUpper(),
                   Email = "clone@gmail.com",
                   NormalizedEmail = "clone@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Nam@123")
               },
               new ApplicationUser
               {
                   Id = "2b2e0d9b-74dd-4928-8c24-1a3156d9fc41",
                   UserName = "Guest",
                   NormalizedUserName = "Guest".ToUpper(),
                   Email = "guest@gmail.com",
                   NormalizedEmail = "guest@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Nam@123")
               }
               
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                // =================== Inser Admin Role =======================
                new IdentityUserRole<string>
                {
                    UserId = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                    RoleId = "2ca8fa08-4a80-4714-a5fb-17b7316fddc4"
                },
                new IdentityUserRole<string>
                {
                    UserId = "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                    RoleId = "2ca8fa08-4a80-4714-a5fb-17b7316fddc4"
                },

                // =================== Inser Creator Role =======================
                new IdentityUserRole<string>
                {
                    UserId = "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                    RoleId = "c6de4ab5-2df7-4a6c-9bbd-2e1b68f8ebdd"
                },
                new IdentityUserRole<string>
                {
                    UserId = "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                    RoleId = "c6de4ab5-2df7-4a6c-9bbd-2e1b68f8ebdd"
                },
                new IdentityUserRole<string>
                {
                    UserId = "51274390-9171-49dd-a3e7-6e23fbf327fb",
                    RoleId = "c6de4ab5-2df7-4a6c-9bbd-2e1b68f8ebdd"
                },
                new IdentityUserRole<string>
                {
                    UserId = "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                    RoleId = "c6de4ab5-2df7-4a6c-9bbd-2e1b68f8ebdd"
                },

                // =================== Inser Customer Role =======================
                new IdentityUserRole<string>
                {
                    UserId = "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                    RoleId = "f28ad7f6-6c3d-4f0f-b9a4-60bca4b57bb3"
                },
                new IdentityUserRole<string>
                {
                    UserId = "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                    RoleId = "f28ad7f6-6c3d-4f0f-b9a4-60bca4b57bb3"
                },
                new IdentityUserRole<string>
                {
                    UserId = "2b2e0d9b-74dd-4928-8c24-1a3156d9fc41",
                    RoleId = "f28ad7f6-6c3d-4f0f-b9a4-60bca4b57bb3"
                }


            );
        }
    }
}
