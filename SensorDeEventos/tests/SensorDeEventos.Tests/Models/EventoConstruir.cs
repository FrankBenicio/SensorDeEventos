
using SensorDeEventos.Domain.Models;
using System;
using Xunit;

namespace SensorDeEventos.Tests.Models
{
    public class EventoConstruir
    {
        [Fact]
        public void DeveRetonarObjetoConstruido()
        {
            var tag = "brasil.sudeste.sensor01";
            var timeStamp = 1539112021301;
            var valor = "10";
            var id = Guid.NewGuid();

            var evento = new Evento(id: id, timeStamp: timeStamp, tag: tag, valor: valor);

            Assert.Equal(tag, evento.Tag);
            Assert.Equal(timeStamp, evento.TimeStamp);
            Assert.Equal(valor, evento.Valor);
            Assert.Equal(id, evento.Id);
        }
    }
}
