
using Microsoft.AspNetCore.Mvc;
using SensorDeEventos.Web.Models;
using System.Threading.Tasks;

namespace SensorDeEventos.Web.Controllers
{
    public class GraficoController : Controller
    {
        public async Task<IActionResult> GerarGraficoPorRegiao([FromServices] GerarGrafico gerarGrafico)
        {
            var resultado = await gerarGrafico.PorRegiao();

            return Json(resultado);
        }
        public async Task<IActionResult> GerarGraficoPorSensor([FromServices] GerarGrafico gerarGrafico)
        {
            var resultado = await gerarGrafico.PorSensor();

            return Json(resultado);
        }
    }
}
