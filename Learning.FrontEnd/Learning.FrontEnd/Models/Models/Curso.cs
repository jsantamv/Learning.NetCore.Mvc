using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learning.FrontEnd.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        [Required]
        public override string Nombre { get; set; }
        public string Direccion { get; set; }

        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }



    }
}