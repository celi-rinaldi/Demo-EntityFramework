using Datos.Data;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Admin
{
    public static class AdmMedico
    {
        static DBClinicaContext context = new DBClinicaContext();
        public static List<Medico> Listar()
        {

            return context.Medicos.ToList();
        }
        public static int Modificar(Medico m)
        {
            Medico medicoOrigen = context.Medicos.Find(m.MedicoId);
            if (medicoOrigen != null)
            {
                medicoOrigen.Nombre = m.Nombre;
                medicoOrigen.Apellido = m.Apellido;
                medicoOrigen.Matricula = m.Matricula;
                medicoOrigen.EspecialidadId = m.EspecialidadId; 
                return context.SaveChanges();
            }
            return 0;
        }
        public static int Eliminar(int id)
        {
            Medico medico = context.Medicos.Find(id);
            if (medico != null)
            {
                context.Medicos.Remove(medico);
                return context.SaveChanges();
            }
            return 0;
        }
        public static Medico TraerUno(int id)
        {
            return context.Medicos.Find(id);
        }
        public static int Insertar(Medico m)
        {
            context.Medicos.Add(m);
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }
        public static List<Medico> ListarPorEspecialidad(int especialidadId)
        {
            List<Medico> medicos = (from m in context.Medicos where m.EspecialidadId == especialidadId
                                    select m).ToList();
            return medicos;
        }
    }
}
