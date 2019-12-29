using System;
using System.Collections.Generic;

namespace Learning.FrontEnd.Models
{
    public class Alumno : ObjetoEscuelaBase
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }

        /*Colecciones de evaluaciones */
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}