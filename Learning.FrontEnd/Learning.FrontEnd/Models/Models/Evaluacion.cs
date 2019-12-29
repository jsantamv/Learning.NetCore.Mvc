using System;

namespace Learning.FrontEnd.Models
{
    public class Evaluacion : ObjetoEscuelaBase
    {
        /*Referencia al alumno*/
        public string AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        
        /*Referencia a la Asignatura*/
        public Asignatura Asignatura { get; set; }
        public string AsignaturaId { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}