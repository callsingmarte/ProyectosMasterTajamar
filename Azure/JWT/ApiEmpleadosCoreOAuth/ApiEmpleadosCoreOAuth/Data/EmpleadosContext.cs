﻿using ApiEmpleadosCoreOAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleadosCoreOAuth.Data
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base (options)
        {
            
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
