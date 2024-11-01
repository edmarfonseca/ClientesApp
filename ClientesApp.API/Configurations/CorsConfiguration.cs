namespace ClientesApp.API.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ClientesPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        public static void UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors("ClientesPolicy");
        }

    }
}