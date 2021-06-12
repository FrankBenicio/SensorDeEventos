using SensorDeEventos.Data.Contexto;
using SensorDeEventos.Domain.Models;
using SensorDeEventos.Historias.EventoHistoria.Dto;
using System.Threading.Tasks;

namespace SensorDeEventos.Historias.EventoHistoria
{
    public class CadastrarEvento
    {
        private readonly SensorDeEventosContexto _contexto;

        public CadastrarEvento(SensorDeEventosContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Executar(PostEventoDto eventoDto)
        {
            Evento evento = eventoDto;

            await _contexto.AddAsync(evento);

            await _contexto.SaveChangesAsync();
        }
    }
}
