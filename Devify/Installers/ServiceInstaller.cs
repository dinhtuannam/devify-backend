using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.Services;
using Devify.Application.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Devify.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //  =========================  DbContext ========================================
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Devify"));
            });


            //  =========================  Identity ========================================
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();


            //  =========================  Cấu hình Repository ==============================
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();


            //  =========================  Cấu hình AutoMapper ===============================
            services.AddAutoMapper(typeof(AutoMapperConfig));


            //  ===========================  Cấu hình MediatR ================================
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
