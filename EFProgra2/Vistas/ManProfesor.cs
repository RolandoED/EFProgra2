using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFProgra2
{
    public partial class MAIN : Form
    {
        ControladorProfesor controladorprofesor = new ControladorProfesor();
        EntidadProfesor entidadprofesor = new EntidadProfesor();  

        public MAIN()
        {
            InitializeComponent();
        }
        //limpiar campos
        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void limpiarCampos()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
        }

        private void cargarEntidad()
        {
            entidadprofesor.Cedula = Convert.ToInt32(txtCedula.Text);
            entidadprofesor.Nombre = txtNombre.Text;
            entidadprofesor.Apellido = txtApellido.Text;
        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void cargarGrid()
        {
            dataGridView1.DataSource = controladorprofesor.leer();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            controladorprofesor.insertar(entidadprofesor);
            cargarGrid();
            limpiarCampos();
        }
    }
}
