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
            string conexion = "Data Source=(local); " +
            "Initial Catalog=bd_colegio;" +
            "Integrated Security=True;";
            SqlConnection sqlconn = new SqlConnection(conexion);

            DataTable dt1 = new DataTable();
            dt1 = new DataTable();
            string sqlquery = "select id_materia, nombre + '  id prof ' + id_profesor from materia;";

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
        }
    }
}
