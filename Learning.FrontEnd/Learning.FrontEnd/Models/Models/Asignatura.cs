using System;
using System.Linq;
using System.Collections.Generic;

namespace Learning.FrontEnd.Models
{
    public class Asignatura : ObjetoEscuelaBase
    {
        /* Referencia hacia su padre */
        public string CursoId { get; set; }
        public Curso Curso { get; set; }

        /*Colecciones de evaluaciones */
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}