using Devify.Application.Interfaces;
using Devify.Infrastructure.Services;
using Devify.Installers;
using Devify.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.InstallerServicesInAssembly(builder.Configuration);
builder.Services.AddScoped<IVnPayService,VnPayRepository>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseTokenMiddleware();
app.UseExceptionHandlerMiddleware();
app.MapControllers();

app.Run();
