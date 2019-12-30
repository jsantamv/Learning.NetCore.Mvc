using System;
using Microsoft.AspNetCore.Mvc;
using Learning.FrontEnd.Models;
using System.Collections.Generic;
using System.Linq;

namespace Learning.FrontEnd.Controllers
{
    public class AlumnoController : Controller
    {


        //Craecion del Contexto de escuela
        private EscuelaContext _context;

        /// <summary>
        /// Constructor dinamico por contexto.
        /// </summary>
        /// <param name="context"></param>
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }


        [Route("Alumno/Index")]
        [Route("Alumno/Index/{Id?}")]
        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var lista = from obj in _context.Alumnos
                            where obj.Id == id
                            select obj;

                return View(lista.SingleOrDefault());
            }
            else
            {
                //ya esto se resuelve en el primer index, esto es meramente como aprendizaje
                return View("MultiAlumno", _context.Alumnos);
            }
        }

        public IActionResult MultiAlumno()
        {
            //var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAlumno", _context.Alumnos);
        }
      
    }
}