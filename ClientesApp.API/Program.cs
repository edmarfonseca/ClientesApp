using ClientesApp.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddCorsConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddDependencyInjection();

var app = builder.Build();

app.UseCorsConfiguration();
app.UseSwaggerConfiguration();
app.UseAuthorization();
app.MapControllers();
app.Run();