using GestionRecursosHumanos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos.Data
{
    public class GestionRecursosContext : DbContext
    {
        public DbSet<Beneficios> Beneficio { get; set;}
        public DbSet<Cargos> Cargo { get; set;}
        public DbSet<Departamentos> Departamento { get; set;}
        public DbSet<Empleados> Empleado { get; set;}
        public DbSet<Nominas> Nomina { get; set;}
        public DbSet<User> Users { get; set;}
    }
}
