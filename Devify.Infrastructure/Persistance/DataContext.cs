using Devify.Entity;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Persistance
{
    public class DataContext : DbContext
    {
        public static Random random = new Random();
        public DbSet<SqlCourse> courses { get; set; }
        public DbSet<SqlChapter> chapters { get; set; }
        public DbSet<SqlLesson> lessons { get; set; }
        public DbSet<SqlLanguage> languages { get; set; }
        public DbSet<SqlToken> tokens { get; set; }
        public DbSet<SqlCategory> categories { get; set; }
        public DbSet<SqlOrder> orders { get; set; }
        public DbSet<SqlDetailOrder> detailOrders { get; set; }
        public DbSet<SqlLevel> courseLevels { get; set; }
        public DbSet<SqlComment> comments { get; set; }
        public DbSet<SqlNotification> notifications { get; set; }
        public DbSet<SqlRole> roles { get; set; }
        public DbSet<SqlTransaction> transactions { get; set; }
        public DbSet<SqlRating> ratings { get; set; }
        public DbSet<SqlDiscount> discounts { get; set; }
        public DbSet<SqlUser> users { get; set; }

        public static string configSql = "Host=dpg-cmf3dkmd3nmc739dj1fg-a.singapore-postgres.render.com:5432;Database=db_devify;Username=db_devify_user;Password=rxB3v2YwsCSjMkG7l0fgFugMPtbM4wsa";

        public static string randomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(configSql);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SqlCourse>().HasMany<SqlLanguage>(s => s.languages).WithMany(s => s.courses);
            modelBuilder.Entity<SqlCourse>().HasMany<SqlLevel>(s => s.levels).WithMany(s => s.courses);
        }
    }
}
