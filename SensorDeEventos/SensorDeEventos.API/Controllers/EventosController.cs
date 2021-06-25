using Microsoft.AspNetCore.Mvc;
using SensorDeEventos.Historias.EventoHistoria;
using SensorDeEventos.Historias.EventoHistoria.Dto;
using System;
using System.Threading.Tasks;

namespace SensorDeEventos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> GetAllEvento([FromServices] ListarEventos listarEventos)
        {
            try
            {
                var eventos = await listarEventos.Executar();

                return new ObjectResult(eventos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostEvento([FromServices] CadastrarEvento cadastrarEvento, PostEventoDto evento)
        {
            if (ModelState.IsValid)
            {
                await cadastrarEvento.Executar(evento);

                return Ok();
            }

            return BadRequest(new
            {
                data = ModelState

            });
        }
    }
}
