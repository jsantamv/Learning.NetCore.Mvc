using System;
using Microsoft.AspNetCore.Mvc;
using Learning.FrontEnd.Models;

namespace Learning.FrontEnd.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var asignatura = new Asignatura{
                UniqueId = Guid.NewGuid().ToString(),
                Nombre="Programación"
            };

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View(asignatura);
        }
    }
}