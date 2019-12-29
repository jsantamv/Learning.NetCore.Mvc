using System;
using System.Collections.Generic;


namespace Learning.FrontEnd.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        /* Referencia hacia su padre */
        public Escuela Escuela { get; set; }
        public string EscuelaId { get; set; }

        /* Colecciones de asignaturas */
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        public TiposJornada Jornada { get; set; }
        public string Dirección { get; set; }



    }
}