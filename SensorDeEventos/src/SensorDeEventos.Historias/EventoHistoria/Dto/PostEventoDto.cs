
using SensorDeEventos.Domain.Models;
using System;

namespace SensorDeEventos.Historias.EventoHistoria.Dto
{
    public class PostEventoDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public long TimeStamp { get; set; }

        public string Tag { get; set; }

        public string Valor { get; set; }


        public static implicit operator Evento(PostEventoDto eventoDto)
        {
            return new Evento(id: eventoDto.Id, timeStamp: eventoDto.TimeStamp, valor: eventoDto.Valor, tag: eventoDto.Tag);
        }

    }
}
