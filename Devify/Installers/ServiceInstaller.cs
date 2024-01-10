using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.Services;
using Devify.Application.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Devify.Infrastructure.SeedWorks;
using Devify.Mappings;

namespace Devify.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //  =========================  DbContext ========================================
            services.AddDbContext<DataContext>(options => options.UseNpgsql(DataContext.configSql));

            //  =========================  Cấu hình Repository ==============================
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //  =========================  Cấu hình AutoMapper ===============================
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddAutoMapper(typeof(CategoryMapper));


            //  ===========================  Cấu hình MediatR ================================
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
