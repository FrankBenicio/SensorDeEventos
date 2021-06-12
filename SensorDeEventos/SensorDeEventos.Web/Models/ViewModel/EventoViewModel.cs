using System;

namespace SensorDeEventos.Web.Models.ViewModel
{
    public class EventoViewModel
    {
        public Guid Id { get; set; }

        public string Pais { get; set; }
        public string Regiao { get; set; }
        public string Sensor { get; set; }
        public int Valor { get; set; }
        public string Status { get; set; }
        public DateTime DataEHora { get; set; }
    }
}
