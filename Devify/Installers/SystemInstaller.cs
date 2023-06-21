using Devify.Application.Interfaces;
using Devify.Infrastructure.Services;

namespace Devify.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
