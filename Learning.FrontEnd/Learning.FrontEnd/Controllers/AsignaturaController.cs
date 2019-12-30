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

        [Route("Asignatura/Index")]
        public IActionResult Index()
        {
            //return View(_context.Asignaturas.FirstOrDefault());
            return View("MultiAsignatura", _context.Asignaturas);
        }

        /// <summary>
        /// Se puede tener varias rutas de enrutamiento
        /// como se le muestra a continuacion
        /// </summary>
        /// <param name="asignaturaId"></param>
        /// <returns></returns>
        //[Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId?}")]
        public IActionResult Index(string asignaturaId)
        {
            var asignatura = from asig in _context.Asignaturas
                             where asig.Id == asignaturaId
                             select asig;

            return View(asignatura.SingleOrDefault());
        }

        public IActionResult MultiAsignatura()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAsignatura", _context.Asignaturas);
        }
    }
}