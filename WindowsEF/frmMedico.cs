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
    public partial class frmMedico : Form
    {
        public frmMedico()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Medico m = new Medico()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Matricula = Convert.ToInt32(txtMatricula.Text),
                EspecialidadId = Convert.ToInt32(comboEspecialidad.SelectedValue)   
            };
            int filasAfectadas = AdmMedico.Insertar(m); 
            if (filasAfectadas > 0)
            {
                MostrarTodos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            int filasAfectadas = AdmMedico.Eliminar(id); 
            if(filasAfectadas > 0)
            {
                MostrarTodos();
            }
        }

        private void MostrarTodos()
        {
            gridMedicos.DataSource = AdmMedico.Listar();
        }

        private void frmMedico_Load(object sender, EventArgs e)
        {
            MostrarTodos();
            LlenarComboEspecialidad();
            LlenarComboTraerPorEspecialidad();
        }

        private void LlenarComboTraerPorEspecialidad()
        {
            List<Especialidad> especialidades = AdmEspecialidad.Listar();
                especialidades.Insert(0, new Especialidad()
                {
                    Id = 0,
                    Nombre = "Todas"
                });
            

            comboBuscarPorEspecialidad.DataSource = especialidades;
            comboBuscarPorEspecialidad.DisplayMember = "Nombre";
            comboBuscarPorEspecialidad.ValueMember = "Id";

        }

        private void LlenarComboEspecialidad()
        {
            List<Especialidad> especialidades = AdmEspecialidad.Listar();
            comboEspecialidad.DataSource = especialidades;
            comboEspecialidad.DisplayMember = "Nombre";
            comboEspecialidad.ValueMember = "Id";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Medico m = new Medico()
            {
                MedicoId = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Matricula = Convert.ToInt32(txtMatricula.Text),
                EspecialidadId = Convert.ToInt32(comboEspecialidad.SelectedValue)
            };
            int filasAfectadas = AdmMedico.Modificar(m);
            if (filasAfectadas > 0)
            {
                MostrarTodos();
            }
        }

        private void comboBuscarPorEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBuscarPorEspecialidad.SelectedValue);
            if(id == 0)
            {
                MostrarTodos();
            }
            else
            {
                gridMedicos.DataSource = AdmMedico.ListarPorEspecialidad(id);
            }
        }
    }
}
