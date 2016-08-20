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
    public partial class ManMateria : Form
    {
        ControladorMateria controladormateria = new ControladorMateria();
        EntidadMateria entidadmateria = new EntidadMateria();

        public ManMateria()
        {
            InitializeComponent();
        }

        private void ManMateria_Load(object sender, EventArgs e)
        {
            try
            {
                cmbProfesor.DropDownStyle = ComboBoxStyle.DropDownList;
                string conexion = "Data Source=(local); " +
                    "Initial Catalog=bd_colegio;" +
                    "Integrated Security=True;";
                SqlConnection sqlconn = new SqlConnection(conexion);

                DataTable dt1 = new DataTable();
                dt1 = new DataTable();
                string sqlquery = "select id_profesor, nombre + '  ' +apellido from profesor;";

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
                cmbProfesor.DataSource = new BindingSource(data, null);
                cmbProfesor.DisplayMember = "Value";
                cmbProfesor.ValueMember = "Key";
                cmbProfesor.SelectedIndex = 0;
                cargarGrid();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Console.WriteLine("Ya existe un Empleado con el ID ");                    
                }
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Message);
            }
        }

        private void cargarGrid()
        {
            dataGridView1.DataSource = controladormateria.leer();
        }

        private void limpiarCampos()
        {
            txtIDMateria.Text = "";
            txtNombre.Text = "";
            cmbProfesor.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //limpiar
            limpiarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //insert into table
            cargarEntidad();
            controladormateria.insertar(entidadmateria);
            cargarGrid();
            limpiarCampos();
        }

       private void cargarEntidad()
       {
            //fill entity with data
            entidadmateria.Id = Convert.ToInt32(txtIDMateria.Text);
            entidadmateria.Nombre = txtNombre.Text;
            entidadmateria.Id_Profesor = Int32.Parse(cmbProfesor.SelectedValue.ToString());            
        }

       private void btnEliminar_Click(object sender, EventArgs e)
       {
           //Eliminar
           controladormateria.eliminar(Convert.ToInt32(txtIDMateria.Text));
           cargarGrid();
           limpiarCampos();
       }

       private void btnModificar_Click(object sender, EventArgs e)
       {
           //update table
           cargarEntidad();
           controladormateria.modificar(entidadmateria);
           cargarGrid();
           limpiarCampos();
       }

       private void dataGridView1_SelectionChanged(object sender, EventArgs e)
       {
           try
           {
               if (dataGridView1.SelectedRows.Count > 0)
               {
                   txtIDMateria.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                   txtNombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                   //SETEAR EL COMBO
                   //txtApellido.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
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
