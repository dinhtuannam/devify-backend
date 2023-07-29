namespace Devify.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //  =======================================================================
            //  =========================  Cấu hình Project ===========================
            
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();


            //  =======================================================================
            //  =========================  Cấu hình Cors ==============================
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


            //  =======================================================================
            //  =========================  Cấu hình Policy ============================
            services.AddAuthorization(options =>
             {
                 options.AddPolicy("RequireAdminRole", policy =>
                     policy.RequireClaim("RoleId", "Admin"));
             });
        }
    }
}
