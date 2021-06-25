using System;
using System.ComponentModel.DataAnnotations;

namespace SensorDeEventos.Web.Models.ViewModel
{
    public class EventoViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "País")]
        public string Pais { get; set; }


        [Display(Name = "Região")]
        public string Regiao { get; set; }

        [Display(Name = "Sensor")]
        public string Sensor { get; set; }

        [Display(Name = "Valor")]
        public int Valor { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Data de entrada")]
        public string DataDeEntrada { get; set; }

        [Display(Name = "Horário de entrada")]
        public string HorarioDeEntrada { get; set; }

        public void ConcatenarRegiao()
        {
            Regiao = $"{Pais}.{Regiao}";
        }

        public void ConcatenarSensor()
        {
            Sensor = $"{Pais}.{Regiao}.{Sensor}";
        }
    }
}
