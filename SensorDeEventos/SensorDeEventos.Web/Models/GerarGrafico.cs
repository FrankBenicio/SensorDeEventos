
using SensorDeEventos.Web.Models.ViewModel;
using SensorDeEventos.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDeEventos.Web.Models
{
    public class GerarGrafico
    {
        private readonly SensorDeEventosServices sensorDeEventosServices;

        public GerarGrafico(SensorDeEventosServices sensorDeEventosServices)
        {
            this.sensorDeEventosServices = sensorDeEventosServices;
        }

        public async Task<object> PorRegiao()
        {
            var eventos = await sensorDeEventosServices.GetAll();
            eventos.ForEach(x => x.ConcatenarRegiao());
            return AgruparDadosPor(x => x.Regiao, eventos);
        }

        public async Task<object> PorSensor()
        {
            var eventos = await sensorDeEventosServices.GetAll();
            eventos.ForEach(x => x.ConcatenarSensor());
            return AgruparDadosPor(x => x.Sensor, eventos);
        }

        private object AgruparDadosPor(Func<EventoViewModel, string> group, List<EventoViewModel> eventos)
        {
            var resultado = eventos.Where(x => x.Valor > 0)
                .GroupBy(group)
                .Select(x => new
                {
                    name = x.Key,
                    y = x.Sum(y => y.Valor)
                }).ToList();


            return resultado;
        }

    }
}
