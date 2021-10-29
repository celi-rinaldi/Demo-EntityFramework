using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Datos.Data;
using Datos.Models;

namespace Datos.Admin
{
   public static class AdmPaciente
    {
       static DBClinicaContext context = new DBClinicaContext();
        public static List<Paciente> Listar()
        {

             return context.Pacientes.ToList();
        }
        public static Paciente TraerPorId(int id)
        {
            return context.Pacientes.Find(id);
        }
        public static int Insertar(Paciente p)
        {
            context.Pacientes.Add(p);
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }
        public static int Modificar(Paciente p)
        {
            Paciente pacienteOrigen = context.Pacientes.Find(p.Id);
            if(pacienteOrigen != null)
            {
                pacienteOrigen.Nombre = p.Nombre;
                pacienteOrigen.Apellido = p.Apellido;
                pacienteOrigen.FechaNacimiento = p.FechaNacimiento;
                pacienteOrigen.NroHistoriaClinica = p.NroHistoriaClinica;
                pacienteOrigen.MedicoId = p.MedicoId;
                return context.SaveChanges();
            }
            return 0; 
        }
        public static int Eliminar(int id)
        {
            Paciente paciente = context.Pacientes.Find(id);
            if(paciente != null)
            {
                context.Pacientes.Remove(paciente);
                return context.SaveChanges();
            }
            return 0;
        }



    }
}
