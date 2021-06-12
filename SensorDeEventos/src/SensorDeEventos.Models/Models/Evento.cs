using SensorDeEventos.Domain.Enums;
using System;

namespace SensorDeEventos.Domain.Models
{
    public class Evento
    {
        public Evento(Guid id, long timeStamp, string tag, string valor)
        {
            Id = id;
            TimeStamp = timeStamp;
            Tag = tag;
            Valor = valor;
            DefinirStatus();
        }

        protected Evento(){}
        
        public Guid Id { get; private set; }

        public long TimeStamp { get; private set; }

        public string Tag { get; private set; }

        public string Valor { get; private set; }

        public Status Status { get; private set; }

        private void DefinirStatus()
        {
            Status = string.IsNullOrEmpty(Valor) ? Status.Error : Status.Processado;
        }
    }
}
