using Application.Services;

namespace MinimalAPI.Extensions
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(o =>
            {
                o.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                      // builder.WithOrigins(MyAllowSpecificOrigins);  
                                      //builder.WithOrigins("http://exemple1.com", "http://exemple2.com");

                                  });
            });
            return services;
        }
    }
}
