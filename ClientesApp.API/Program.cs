using ClientesApp.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(config => { config.LowercaseUrls = true; });
SwaggerConfiguration.AddSwaggerConfiguration(builder.Services);
DependencyInjectionConfiguration.AddDependencyInjection(builder.Services);
CorsConfiguration.AddCorsConfiguration(builder.Services);
JwtSecurityConfiguration.AddJwtSecurity(builder.Services);
var app = builder.Build();

SwaggerConfiguration.UseSwaggerConfiguration(app);
CorsConfiguration.UseCorsConfiguration(app);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
