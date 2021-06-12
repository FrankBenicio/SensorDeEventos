
using SensorDeEventos.Domain.Models;
using SensorDeEventos.Historias.Extensoes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SensorDeEventos.Historias.EventoHistoria.Dto
{
    public class GetEventoDto
    {
        public Guid Id { get; set; }
      
        public string Tag { get; set; }

        public string Valor { get; set; }

        public string Status { get; set; }

        public DateTime DataEHora { get; set; }

        public static implicit operator GetEventoDto(Evento evento) 
        {
            var eventoDto = new GetEventoDto
            {
                Id = evento.Id,
                Tag = evento.Tag,
                Valor = evento.Valor,
                DataEHora = evento.TimeStamp.ToDateTime(),
                Status = evento.Status.ToString()
            };

            return eventoDto;
        
        }
    }
}
