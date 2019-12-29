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


        public IActionResult Index()
        {
            return View(_context.Alumnos.FirstOrDefault());
        }

        public IActionResult MultiAlumno()
        {
            //var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAlumno", _context.Alumnos);
        }

        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).ToList();
        }
    }
}