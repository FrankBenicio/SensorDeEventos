using SensorDeEventos.Web.Models.ViewModel;
using System;
namespace SensorDeEventos.Web.Models.Dto
{
    public class EventoDto
    {
        public Guid Id { get; set; }

        public string Tag { get; set; }

        public string Valor { get; set; }

        public string Status { get; set; }

        public DateTime DataEHora { get; set; }

        public static implicit operator EventoViewModel(EventoDto evento)
        {

            return new EventoViewModel
            {
                Id = evento.Id,
                Pais = evento.Tag.Split(".")[0],
                Regiao = evento.Tag.Split(".")[1],
                Sensor = evento.Tag.Split(".")[2],
                DataEHora = evento.DataEHora,
                Status = evento.Status,
                Valor = ConverterValorParaInteiro(evento.Valor)
            };
        }

        private static int ConverterValorParaInteiro(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) ? Convert.ToInt32(valor) : 0;
        }
    }
}
