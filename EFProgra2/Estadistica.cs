using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace EFProgra2
{
    public abstract class Estadistica
    {
        //Body
        public abstract string GENERAR();

        //Body
        public abstract string MOSTRAR();

        //Body
        public abstract string IMPRIMIR();
        
        //Constructor
        public Estadistica(){}

    }


    public class EstadisticaColegio : Estadistica
    {
        string conexion = "Data Source=(local);Initial Catalog=bd_colegio;"+
            "Integrated Security=True;";
        SqlConnection sqlconn;
        //string reporteGENERAL = "";

        public override string GENERAR()
        {
            return "MESSAGE FROM THE CHILD!";
        }

        public override string MOSTRAR()
        {
            return "MESSAGE FROM THE CHILD!";
        }

        public override string IMPRIMIR()
        {
            return "MESSAGE FROM THE CHILD!";
        }

        public void conectarBD()
        {
            sqlconn = new SqlConnection(conexion);
            try
            {
                sqlconn.Open();
            }
            catch (Exception e)
            {
                var message = MessageBox.Show("Conexion fallida! Error: " + e.Message.ToString());
            }
        }

        public void desconectarBD()
        {
            sqlconn.Close();
        }

        public void ejecutarSQL(string sql)
        {
            SqlCommand sqlcomm = new SqlCommand();
            conectarBD();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandText = sql;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.ExecuteNonQuery();
            desconectarBD();
        }

        //public string ContadorPorMateria()
        //{
        //    String query = " ";
        //    SqlConnection con = new SqlConnection(conexion);
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    con.Open();
        //    cmd.CommandText = " select e.id_materia , count(*) "+
        //     "from estudiante e"+
        //     "where e.id_materia IN (SELECT ID_MATERIA from MATERIA) "+
        //     "group by e.id_materia;";
        //    Int32 count = (Int32)cmd.ExecuteScalar();
        //    return count;
        //}

        SELECT 
ID_ESTUDIANTE AS Cedula, NOMBRE AS Nombre, APELLIDO AS Apellido, DIRECCION AS Direccion, EDAD AS Edad, ID_MATERIA AS ID_Materia 
 FROM ESTUDIANTE 
 
 select id_materia, nombre  from materia;
 
 select count(*) from estudiante where estudiante.edad >= 18;
 
 select m.id_profesor , count(*) 
 from  materia m JOIN estudiante e 
 ON m.id_materia = e.id_materia
 group by m.id_materia;

        public void Asistencia()
        {
            String query = " select e.id_materia , count(*) " +
                 "from estudiante e " +
                 "where e.id_materia IN (SELECT ID_MATERIA from MATERIA) " +
                 "group by e.id_materia; ";
            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            con.Open();

            dbr = cmd.ExecuteReader();
            int count = 0;
            while (dbr.Read())
            {
                Console.WriteLine("__________");
                count = count + 1;
                //ndepto id
                Console.WriteLine("DEPTO ID: " + dbr.GetInt32(0));
                //apellido
                Console.WriteLine("Estudiantes : " + dbr.GetInt32(1));
            }
            con.Close();
        }

        public void ContadorPorMateria()
        {
                String query = " select e.id_materia , count(*) " +
                     "from estudiante e "+
                     "where e.id_materia IN (SELECT ID_MATERIA from MATERIA) " +
                     "group by e.id_materia; ";
                SqlConnection con = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dbr;
                con.Open();

                dbr = cmd.ExecuteReader();
                int count = 0;
                while (dbr.Read())
                {
                    Console.WriteLine("__________");
                    count = count + 1;
                    //ndepto id
                    Console.WriteLine("DEPTO ID: " + dbr.GetInt32(0));
                    //apellido
                    Console.WriteLine("Estudiantes : " + dbr.GetInt32(1));
                }
                con.Close();
        }

        public int Mayor18( )
        {
            String query = " ";
            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.CommandText = "select count(*) from estudiante where estudiante.edad >= 18";
            Int32 count = (Int32)cmd.ExecuteScalar();
            return count;
        }

        public int Menor18()
        {
            String query = " ";
            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.CommandText = "select count(*) from estudiante where estudiante.edad < 18;";
            Int32 count = (Int32)cmd.ExecuteScalar();
            return count;
        }

    }
}
