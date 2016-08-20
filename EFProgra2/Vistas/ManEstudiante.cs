using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Data.Sql;
using System.Data.SqlClient;

namespace EFProgra2
{
    public partial class ManEstudiante : Form
    {
        ControladorEstudiante controladorestudiante = new ControladorEstudiante();
        EntidadEstudiante entidadestudiante = new EntidadEstudiante();

        public ManEstudiante()
        {
            InitializeComponent();
        }

        private void ManEstudiante_Load(object sender, EventArgs e)
        {
            cargarGrid();
            cargarCombo();
        }        

        private void cargarGrid()
        {
            dataGridView1.DataSource = controladorestudiante.leer();
        }

        private void cargarCombo()
        {
            string conexion = "Data Source=(local); " +
            "Initial Catalog=bd_colegio;" +
            "Integrated Security=True;";
            SqlConnection sqlconn = new SqlConnection(conexion);

            DataTable dt1 = new DataTable();
            dt1 = new DataTable();
            string sqlquery = "select id_materia, nombre from materia ;";

            sqlconn = new SqlConnection(conexion);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlconn.Open();
            sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt1);
            sqlconn.Close();
            Dictionary<int, string> data = new Dictionary<int, string>();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                data.Add(int.Parse(dt1.Rows[i][0].ToString()), dt1.Rows[i][1].ToString());
            }
            cmbMateria.DataSource = new BindingSource(data, null);
            cmbMateria.DisplayMember = "Value";
            cmbMateria.ValueMember = "Key";
            cmbMateria.SelectedIndex = 0;
            cargarGrid();
        }


        private void limpiarCampos()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            cmbMateria.SelectedIndex = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void cargarEntidad()
        {
            //fill entity with data
            entidadestudiante.Id_Estudiante = Convert.ToInt32(txtCedula.Text);
            entidadestudiante.Nombre = txtNombre.Text;
            entidadestudiante.Apellido = txtApellido.Text;
            entidadestudiante.Direccion = txtDireccion.Text;
            entidadestudiante.Edad = Convert.ToInt32(txtEdad.Text);
            entidadestudiante.Id_Materia = Int32.Parse(cmbMateria.SelectedValue.ToString());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //insert into table
            cargarEntidad();
            controladorestudiante.insertar(entidadestudiante);
            cargarGrid();
            limpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //update table
            cargarEntidad();
            controladorestudiante.modificar(entidadestudiante);
            cargarGrid();
            limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar
            controladorestudiante.eliminar(Convert.ToInt32(txtCedula.Text));
            cargarGrid();
            limpiarCampos();
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
                    txtDireccion.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    txtEdad.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    //asignar
                    for (int i = 0; i < cmbMateria.Items.Count; i++)
                    {
                        string value = cmbMateria.GetItemText(cmbMateria.Items[i]);
                        Console.WriteLine(value);
                    }
                       
                }
            }
            catch (Exception)
            {
                Console.WriteLine(" ");
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            //refresh
            cargarGrid();
        }

    }
}
