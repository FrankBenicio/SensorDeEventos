
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SensorDeEventos.Historias.EventoHistoria;
using SensorDeEventos.Historias.EventoHistoria.Dto;
using SensorDeEventos.Historias.Validators.Evento;

namespace SensorDeEventos.Historias
{
    public static class Setup
    {
        public static void AdicionarHistoria(this IServiceCollection services)
        {
            //Injeção
            services.AddScoped<CadastrarEvento>();
            services.AddScoped<ListarEventos>();

            //validadores
            services.AddTransient<IValidator<PostEventoDto>, EventoDtoValidator>();
        }
    }
}
