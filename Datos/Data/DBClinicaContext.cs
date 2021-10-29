using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Datos.Models;

namespace Datos.Data
{
   public class DBClinicaContext:DbContext
    {
        // constructor
        public DBClinicaContext():base("KeyDbClinica") { }

        // propiedades DbSet<m>
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }

    }
}
