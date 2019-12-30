using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learning.FrontEnd.Models
{
    /// <summary>
    /// Clase curso
    /// se implementan data anotatios
    /// </summary>
    public class Curso : ObjetoEscuelaBase
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(5)]
        public override string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(10, ErrorMessage = "Longitud Minima de {0} es 10")]
        [Display(Prompt = "Direccion Correspondencia", Name = "Addres")]
        public string Direccion { get; set; }

        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }



    }
}