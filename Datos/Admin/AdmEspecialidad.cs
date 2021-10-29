using Datos.Data;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Admin
{
   public static class AdmEspecialidad
    {
        // listar, modificar, insertar, eliminar, traer por id
        static DBClinicaContext context = new DBClinicaContext();
        public static List<Especialidad> Listar()
        {

            return context.Especialidades.ToList();
        }
        public static int Eliminar(int id)
        {
            Especialidad es = context.Especialidades.Find(id);
            if (es != null)
            {
                context.Especialidades.Remove(es);
                return context.SaveChanges();
            }
            return 0;
        }
        public static Especialidad TraerUna(int id)
        {
            return context.Especialidades.Find(id);
        }
        // metodo agregado para poder listar en el grid
        public static List<Especialidad> ListarPorId(int id)
        {
            List<Especialidad> lista = new List<Especialidad>();
            lista.Add(context.Especialidades.Find(id));
            return lista;
        }
        public static int Insertar(Especialidad es)
        {
            context.Especialidades.Add(es);
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }
        public static int Modificar(Especialidad es)
        {
            Especialidad espOrigen = context.Especialidades.Find(es.Id);
            if (espOrigen != null)
            {
                espOrigen.Nombre = es.Nombre;
                espOrigen.Id = es.Id; 
                return context.SaveChanges();
            }
            return 0;
        }
    }
}
