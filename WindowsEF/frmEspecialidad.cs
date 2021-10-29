using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Models;
using Datos.Admin; 

namespace WindowsEF
{
    public partial class frmEspecialidad : Form
    {
        public frmEspecialidad()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = new Especialidad()
            {
                Nombre = txtNombreEsp.Text
            };
            int filasAfectadas = AdmEspecialidad.Insertar(especialidad);
            if (filasAfectadas > 0)
            {
                MostrarTodos();
            }
        }

        private void MostrarTodos()
        {
            gridEspecialidades.DataSource = AdmEspecialidad.Listar(); 
        }

        private void frmEspecialidad_Load(object sender, EventArgs e)
        {
            MostrarTodos();
            LlenarComboEspecialidad();
        }

        private void LlenarComboEspecialidad()
        {
            List<Especialidad> especialidades = AdmEspecialidad.Listar();
            especialidades.Insert(0, new Especialidad()
            {
                Id = 0,
                Nombre = "Todas"
            });


            comboEspecialidades.DataSource = especialidades;
            comboEspecialidades.DisplayMember = "Nombre";
            comboEspecialidades.ValueMember = "Id";
        }

        private void comboEspecialidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboEspecialidades.SelectedValue);
            if (id == 0)
            {
                MostrarTodos();
            }
            else
            {
                gridEspecialidades.DataSource = AdmEspecialidad.ListarPorId(id); 
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            int filasAfectadas = AdmEspecialidad.Eliminar(id); 
            if (filasAfectadas > 0)
            {
                MostrarTodos(); 
            }
        }

        private void btnModficar_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = new Especialidad()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtNombreEsp.Text
            };
            int filasAfectadas = AdmEspecialidad.Modificar(especialidad);
            if (filasAfectadas > 0)
            {
                MostrarTodos();
            }
        }
    }
}
