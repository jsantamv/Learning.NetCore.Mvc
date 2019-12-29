using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Learning.FrontEnd.Models;
using System.Collections.Generic;

namespace Learning.FrontEnd.Controllers
{
    public class AsignaturaController : Controller
    {

        //Craecion del Contexto de escuela
        private EscuelaContext _context;
        /// <summary>
        /// Constructor dinamico por contexto.
        /// </summary>
        /// <param name="context"></param>
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Asignaturas.FirstOrDefault());
        }

        public IActionResult MultiAsignatura()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAsignatura", _context.Asignaturas);
        }
    }
}