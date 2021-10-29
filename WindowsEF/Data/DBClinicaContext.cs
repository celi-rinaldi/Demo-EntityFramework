using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WindowsEF.Models;

namespace WindowsEF.Data
{
   public class DBClinicaContext:DbContext
    {
        // constructor
        public DBClinicaContext():base("KeyDbClinica") { }

        // propiedades DbSet<m>
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
    }
}
