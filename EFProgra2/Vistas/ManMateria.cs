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
        public ManMateria()
        {
            InitializeComponent();
        }

        private void ManMateria_Load(object sender, EventArgs e)
        {
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
        }

        private void cmbProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
