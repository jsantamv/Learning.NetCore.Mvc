using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Learning.FrontEnd.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluacion> Evaluacions { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }


        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        /// <summary>
        /// Sobrescritura para el metodo de LINQ
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Esto es para sobrescribir el comportamiento de On Model Creating
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela
            {
                AñoDeCreación = 2005,
                UniqueId = Guid.NewGuid().ToString(),
                Nombre = "Platzi School",
                Ciudad = "Bogota",
                Pais = "Colombia",
                Dirección = "Avd Siempre viva",
                TipoEscuela = TiposEscuela.Secundaria
            };

            modelBuilder.Entity<Escuela>().HasData(escuela);

            modelBuilder.Entity<Asignatura>().HasData(
                            new Asignatura { Nombre = "Matemáticas", UniqueId = Guid.NewGuid().ToString() },
                            new Asignatura { Nombre = "Educación Física", UniqueId = Guid.NewGuid().ToString() },
                            new Asignatura { Nombre = "Castellano", UniqueId = Guid.NewGuid().ToString() },
                            new Asignatura { Nombre = "Ciencias Naturales", UniqueId = Guid.NewGuid().ToString() },
                            new Asignatura { Nombre = "Programación", UniqueId = Guid.NewGuid().ToString() }
                );

            //Vamos a construir un nuevas entidades de alumnos
            //Pero el Metodo HasData() requiere que se un array y no un enumerable
            // Por eso se tiene que convertir de una lista a  un array
            modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar().ToArray());
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
                                   UniqueId = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.UniqueId).ToList();
        }

    }
}
