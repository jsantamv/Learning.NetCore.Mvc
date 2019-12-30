using System;
using Microsoft.AspNetCore.Mvc;
using Learning.FrontEnd.Models;
using System.Collections.Generic;
using System.Linq;

namespace Learning.FrontEnd.Controllers
{
    public class CursoController : Controller
    {


        //Craecion del Contexto de escuela
        private EscuelaContext _context;

        /// <summary>
        /// Constructor dinamico por contexto.
        /// </summary>
        /// <param name="context"></param>
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }


        [Route("Curso/Index")]
        [Route("Curso")]
        [Route("Curso/Index/{Id?}")]
        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var lista = from obj in _context.Cursos
                            where obj.Id == id
                            select obj;

                return View(lista.SingleOrDefault());
            }
            else
            {
                //ya esto se resuelve en el primer index, esto es meramente como aprendizaje
                return View("MultiCurso", _context.Cursos);
            }
        }

        public IActionResult MultiCurso()
        {
            //var listaCursos = GenerarCursosAlAzar();

            ViewBag.CosaDinamica = "Listado de Cursos";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiCurso", _context.Cursos);
        }

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();

                curso.EscuelaId = escuela.Id;
                curso.Id = Guid.NewGuid().ToString();
                _context.Cursos.Add(curso);
                _context.SaveChanges();

                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }
    }
}