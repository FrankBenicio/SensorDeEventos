using Microsoft.EntityFrameworkCore;
using SensorDeEventos.Data.Contexto;
using SensorDeEventos.Historias.EventoHistoria.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDeEventos.Historias.EventoHistoria
{
    public class ListarEventos
    {
        private readonly SensorDeEventosContexto _contexto;

        public ListarEventos(SensorDeEventosContexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<List<GetEventoDto>> Executar()
        {
            var eventos = await _contexto.Eventos.ToListAsync();

            var eventosDto = eventos.Select(evento => {

                GetEventoDto eventoDto = evento;

                return eventoDto;

            }).ToList();

            return eventosDto;
        }
    }
}
