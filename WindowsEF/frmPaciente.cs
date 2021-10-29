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
    public partial class frmPaciente : Form
    {
        public frmPaciente()
        {
            InitializeComponent();
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            gridPacientes.DataSource = AdmPaciente.Listar();

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Paciente p = new Paciente()
            {
                Nombre = "Ana",
                Apellido = "Fernandez",
                FechaNacimiento = new DateTime(2000, 1, 20),
                NroHistoriaClinica = 111,
                MedicoId = 1
            };
            int filasAfectadas = AdmPaciente.Insertar(p); 
            if(filasAfectadas > 0)
            {
                traerPacientes(); 
            }
        
        }

        private void traerPacientes()
        {
            gridPacientes.DataSource = AdmPaciente.Listar();
        }
    }
}
