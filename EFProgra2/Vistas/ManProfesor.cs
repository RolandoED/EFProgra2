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
    public partial class ManProfesor : Form
    {

        ControladorProfesor controladorprofesor = new ControladorProfesor();
        EntidadProfesor entidadprofesor = new EntidadProfesor();

        public ManProfesor()
        {
            InitializeComponent();
        }


        private void MENU_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void cargarEntidad()
        {
            //fill entity with data
            entidadprofesor.Cedula = Convert.ToInt32(txtCedula.Text);
            entidadprofesor.Nombre = txtNombre.Text;
            entidadprofesor.Apellido = txtApellido.Text;
        }

        private void cargarGrid()
        {
            dataGridView1.DataSource = controladorprofesor.leer();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //limpiar
            limpiarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //insert into table
            cargarEntidad();
            controladorprofesor.insertar(entidadprofesor);
            cargarGrid();
            limpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //update table
            cargarEntidad();
            controladorprofesor.modificar(entidadprofesor);
            cargarGrid();
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar
            controladorprofesor.eliminar(Convert.ToInt32(txtCedula.Text));
            cargarGrid();
            limpiarCampos();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            //refresh
            cargarGrid();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    txtCedula.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txtNombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    txtApellido.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                }
            }
            catch (Exception)
            {
                Console.WriteLine(" ");
            }
        }
    }
}
