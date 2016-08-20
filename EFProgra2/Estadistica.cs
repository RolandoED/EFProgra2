using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace EFProgra2
{
    public abstract class Estadistica
    {
        //Body
        public abstract void GENERAR();
        //Body
        public abstract string MOSTRAR();
        //Body
        public abstract string IMPRIMIR();        
        //Constructor
        public Estadistica(){}
    }

    public class EstadisticaColegio : Estadistica
    {
        private string conexion = "Data Source=(local);Initial Catalog=bd_colegio;"+
            "Integrated Security=True;";
        //SqlConnection sqlconn;
        private string reporteGENERAL = string.Empty;

        public  override void  GENERAR()
        {
            //TITULO PRINCIPAL
            reporteGENERAL = "\r\n\t\tREPORTE GENERAL DEL COLEGIO ABC\r\n";
            //EDAD:
            reporteGENERAL += "EDAD:\r\n";
            reporteGENERAL += "\tEstudiantes Mayores de 18 Años: ";
            reporteGENERAL += Mayor18()+"\r\n";
            reporteGENERAL += "\tEstudiantes menores de edad : ";
            reporteGENERAL += Menor18() + "\r\n";
            //CUPO:
            reporteGENERAL += "\r\nCUPO:\r\n";
            reporteGENERAL += Asistencia();
            //ASISTENCIA ESTUDAINTES POR PROFESOR:
            reporteGENERAL += "\r\n\r\nASISTENCIA:\r\n";
            reporteGENERAL += ContadorEstudiantesPorProfesor();
            //PROFESORADO cant cursos por prof:
            reporteGENERAL += "\r\nPROFESORADO:\r\n";
            reporteGENERAL += Profesorado();
            //LABORATORIO:
            reporteGENERAL += "\r\nLABORATORIO:\r\n";
            reporteGENERAL += Laboratorio();

        }

        public override string MOSTRAR()
        {
            return reporteGENERAL;
        }

        public override string IMPRIMIR()
        {
            guardarDoc("REPORTEGENERAL.txt",reporteGENERAL);
            return "";
        }

        public bool IsReporteEmpty() {
            if (reporteGENERAL.Equals(""))
            {
                return true;
            }
            else
                return false;
        }

        public string Profesorado()
        {
            string retorno = "";
            String query = " SELECT Profesor.id_profesor as id_prof, "+
            " COUNT(*) as contador "+
            " FROM PROFESOR "+
	        " JOIN Materia "+
		    " ON Materia.id_profesor = Profesor.id_profesor "+
            " GROUP BY Profesor.id_profesor "+
            " ORDER BY count(*) DESC ";
            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            con.Open();
            string profmenos5 = "\r\nProfesores con menos de 5 materias\r\n";
            string profentre5y10 = "\r\nProfesores con de [5-10] materias\r\n";
            string profmas10 = "\r\nProfesores con más de 10 materias\r\n";
            dbr = cmd.ExecuteReader();
            while (dbr.Read())
            {
                retorno += "========== \r\n";
                //id prof
                retorno += "ID Profesor: " + dbr.GetInt64(0) + " \r\n";
                //materias
                retorno += "Cantidad Materias : " + dbr.GetInt32(1)+" \r\n";
                //menos de 5
                if (dbr.GetInt32(1) <= 5)
                {
                    profmenos5 += "\t° ID Profesor: " + dbr.GetInt64(0) + " con: " + dbr.GetInt32(1) + " materias \r\n";
                }
                // de 5 a 10
                else if (dbr.GetInt32(1) > 5 && dbr.GetInt32(1) < 10)
                {
                    profentre5y10 += "\t° ID Profesor: " + dbr.GetInt64(0) + " con: " + dbr.GetInt32(1) + " materias \r\n";
                }
                // mas de 10
                else if (dbr.GetInt32(1) >= 10)
                {
                    profmas10 += "\t° ID Profesor: " + dbr.GetInt64(0) + " con: " + dbr.GetInt32(1) + " materias \r\n";
                }
            }
            con.Close();
            retorno += profmenos5;
            retorno += profentre5y10;
            retorno += profmas10;
            //devuelve valor retorno
            return retorno;
        }

        public string Laboratorio()
        {
            string retorno = "";
            String query = "SELECT COUNT(*) " +
                " from Estudiante " +
                " JOIN Materia " +
                " ON Materia.id_materia = Estudiante.id_materia " +
                " Where Materia.nombre IN ('Informatica','Computacion','Programacion'); ";
            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            con.Open();
            dbr = cmd.ExecuteReader();
            while (dbr.Read())
            {
                retorno += "\r\r\nEstudiantes que necesitan laboratorio: " + dbr.GetInt32(0);                
            }
            con.Close();
            return retorno;
        }


        public string Asistencia()
        {
            string retorno = "";
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
                retorno += "\r\n";
                count = count + 1;
                // id materia
                retorno += "ID Materia: " + dbr.GetInt32(0);
                //contador materias
                retorno += "\r\nEstudiantes : " + dbr.GetInt32(1);
            }
            con.Close();
            return retorno;
        }
        
        // CALCULO DE ESTUDIANTES POR PROFESOR
        public string ContadorEstudiantesPorProfesor()
        {
            string retorno = "";
            String query = "SELECT 	   Profesor.id_profesor as IDPROFESOR, " +
                    "count(*) as 'CANTIDAD Estudiantes' " +
                    "FROM Estudiante " +
                    "JOIN Materia " +
                    "ON Materia.id_materia = Estudiante.id_materia " +
                    "JOIN Profesor " +
                    "ON Profesor.id_profesor = Materia.id_profesor " +
                    "GROUP BY Profesor.id_profesor ";
            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            con.Open();

            dbr = cmd.ExecuteReader();
            int count = 0;
            retorno += "__________\r\n";
            while (dbr.Read())
            {
                count = count + 1;
                //ndepto id
                retorno += "ID Profesor: " + dbr.GetInt64(0);
                //apellido
                retorno += "\r\nCant Estudiantes en sus materias : " + dbr.GetInt32(1) + "\r\n";
            }
            con.Close();
            return retorno;
        }

        // CONTERO DE MAYORES
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

        // CONTERO DE MENORES
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

        //GUARDA EL DOCUMENTO
        public static void guardarDoc(string filename, string send)
        {
            string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
            StreamWriter sw = new StreamWriter(currentPath + "\\" + filename, true, Encoding.ASCII); //Ruta
            sw.Write(send);
            sw.Close();
        }

    }
}
