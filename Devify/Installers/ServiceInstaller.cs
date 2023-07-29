using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.Services;
using Devify.Application.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Devify.Infrastructure.SeedWorks;

namespace Devify.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //  =========================  DbContext ========================================
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Devify"))
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},LogLevel.Information);
            });


            //  =========================  Identity ========================================
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();


            //  =========================  Cấu hình Repository ==============================
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //  =========================  Cấu hình AutoMapper ===============================
            services.AddAutoMapper(typeof(AutoMapperConfig));


            //  ===========================  Cấu hình MediatR ================================
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
