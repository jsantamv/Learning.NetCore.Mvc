using System;
using Microsoft.AspNetCore.Mvc;
using Learning.FrontEnd.Models;

namespace Learning.FrontEnd.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Avd Siempre viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            ViewBag.CosaDinamica = "La Monja";

            return View(escuela);
        }
    }
}