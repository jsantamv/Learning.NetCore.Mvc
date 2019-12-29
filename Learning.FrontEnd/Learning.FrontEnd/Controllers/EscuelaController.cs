using System;
using Microsoft.AspNetCore.Mvc;
using Learning.FrontEnd.Models;
using System.Linq;

namespace Learning.FrontEnd.Controllers
{
    public class EscuelaController : Controller
    {

        //Craecion del Contexto de escuela
        private EscuelaContext _context;
        /// <summary>
        /// Constructor dinamico por contexto.
        /// </summary>
        /// <param name="context"></param>
        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.CosaDinamica = "La Monja";
            var escuela = _context.Escuelas.FirstOrDefault();
            return View(escuela);
        }

        
    }
}