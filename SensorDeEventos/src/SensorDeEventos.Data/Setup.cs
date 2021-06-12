using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SensorDeEventos.Data.Contexto;
using Microsoft.AspNetCore.Builder;

namespace SensorDeEventos.Data
{
    public static class Setup
    {
        public static void AdicionarContexto(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SensorDeEventosContexto>(x => x.EnableSensitiveDataLogging().UseSqlServer(configuration.GetConnectionString("SensorDeEventosContexto")));
        }
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<SensorDeEventosContexto>().Database.Migrate();
            }
        }
    }
}
