using Microsoft.OpenApi.Models;

namespace Devify.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //  =======================================================================
            //  =========================  Cấu hình Project ===========================
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

                // Thêm xác thực vào Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
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
