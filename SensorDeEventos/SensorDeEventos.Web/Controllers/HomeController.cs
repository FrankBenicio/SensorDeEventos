﻿using Microsoft.AspNetCore.Mvc;
using SensorDeEventos.Web.Models;
using SensorDeEventos.Web.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SensorDeEventos.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Eventos([FromServices] SensorDeEventosServices services)
        {
            var eventos = await services.GetAll();

            return View(eventos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
