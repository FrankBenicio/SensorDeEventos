using Microsoft.Extensions.Configuration;
using RestSharp;
using SensorDeEventos.Web.Models.Dto;
using SensorDeEventos.Web.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SensorDeEventos.Web.Services
{
    public class SensorDeEventosServices
    {
        private readonly string Uri;

        public SensorDeEventosServices(IConfiguration configuration)
        {
            Uri = configuration["UriSensoApi"];
        }

        public async Task<List<EventoViewModel>> GetAll()
        {

            var client = new RestClient(Uri);

            var request = new RestRequest("/api/eventos", Method.GET) { RequestFormat = DataFormat.Json };

            var response = await client.ExecuteAsync(request);

            var eventosDto = JsonSerializer.Deserialize<List<EventoDto>>(response.Content);

            var eventosVm = eventosDto.Select(eventoDto => 
            {
                EventoViewModel evento = eventoDto;

                return evento;
            }).ToList();


            return eventosVm;
        }
    }
}
