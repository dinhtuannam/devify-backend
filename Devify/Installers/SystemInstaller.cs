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
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Devify Server", Version = "v1" });

                // Thêm xác thực vào Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Bearer",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
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
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new string[] { }
                    }
                });
            });
            services.AddEndpointsApiExplorer();


            //  =======================================================================
            //  =========================  Cấu hình Cors ==============================
            services.AddCors(options =>
            {
                options.AddPolicy("HTTPSystem", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).WithExposedHeaders("Grpc-Status", "Grpc-Encoding", "Grpc-Accept-Encoding");
                });
            });

        }
    }
}
