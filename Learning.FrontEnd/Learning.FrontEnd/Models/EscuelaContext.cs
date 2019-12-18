﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.FrontEnd.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluacion> Evaluacions { get; set; }


        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

    }
}
