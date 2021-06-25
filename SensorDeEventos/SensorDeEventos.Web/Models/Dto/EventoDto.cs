using SensorDeEventos.Web.Models.ViewModel;
using System;
using System.Text.Json.Serialization;

namespace SensorDeEventos.Web.Models.Dto
{
    public class EventoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("valor")]
        public string Valor { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("dataEHora")]
        public DateTime DataEHora { get; set; }

        public static implicit operator EventoViewModel(EventoDto evento)
        {

            return new EventoViewModel
            {
                Id = evento.Id,
                Pais = evento.Tag.Split(".")[0],
                Regiao = evento.Tag.Split(".")[1],
                Sensor = evento.Tag.Split(".")[2],
                DataDeEntrada = evento.DataEHora.ToString("d"),
                HorarioDeEntrada = evento.DataEHora.ToString("t"),
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
