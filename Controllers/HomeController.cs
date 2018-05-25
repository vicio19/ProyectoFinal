using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinalContext _context;

        public HomeController(FinalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View( _context.Paises.ToList());
           
        }
        public IActionResult Ijugadores(int ? idPais)
        {
            if(idPais!= null)
            {
                return View(_context.Jugadores.Where(juag => juag.PaisID== idPais).ToList());
            }
            else
            {
                return View(_context.Jugadores.ToList());
            }
           

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Muchas Gracias Marquito, por las enseñanzas transmitidas";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Muchas Gracias Marquito, por las enseñanzas transmitidas";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
