using System.Data;


namespace EFProgra2
{
    class ControladorEstudiante
    {
        
        Modelo mod = new Modelo();
        EntidadEstudiante entidad = new EntidadEstudiante();
        string sql;

        public DataTable leer()
        {
            sql = "SELECT "
                + "ID_ESTUDIANTE AS Cedula, "
                + "NOMBRE AS Nombre, "
                + "APELLIDO AS Apellido, "
                + "DIRECCION AS Direccion, "
                + "EDAD AS Edad, "
                + "ID_MATERIA AS ID_Materia "
                + " FROM "
                + "ESTUDIANTE ";
            return mod.llenarDT(sql);
        }

        public DataTable buscar(int id)
        {
            sql = "SELECT "
                + "CEDULA AS Cedula,"
                + "NOMBRE AS Nombre,"
                + "APELLIDO AS Apellido"
                + " FROM "
                + "PROFESOR"
                + " WHERE "
                + "CEDULA = " + id;
            return mod.llenarDT(sql);
        }
        
        public void insertar(EntidadEstudiante entidad)
        {
            sql = "INSERT INTO ESTUDIANTE ("
                + "ID_ESTUDIANTE,"
                + "NOMBRE,"
                + "APELLIDO, "
                + "DIRECCION,"
                + "EDAD,"
                + "ID_MATERIA"
                + ") VALUES ("
                + entidad.Id_Estudiante + ","
                + "'" + entidad.Nombre + "',"
                + "'" + entidad.Apellido + "',"
                + "'" + entidad.Direccion + "',"
                + " " + entidad.Edad + " ,"
                + " " + entidad.Id_Materia + " "
                + ")";
            mod.ejecutarSQL(sql);
        }

        public void modificar(EntidadEstudiante entidad)
        {
            sql = "UPDATE ESTUDIANTE SET "
                + "NOMBRE ='" + entidad.Nombre + "',"
                + "APELLIDO = '" + entidad.Apellido + "', "
                + "DIRECCION ='" + entidad.Direccion + "',"
                + "EDAD = " + entidad.Edad + " ,"
                + "ID_MATERIA = " + entidad.Id_Materia+ " "
                + " WHERE "
                + " ID_ESTUDIANTE = " + entidad.Id_Estudiante;
            mod.ejecutarSQL(sql);
        }

        public void eliminar(int id)
        {
            sql = "DELETE ESTUDIANTE "
                + "WHERE "
                + "ID_ESTUDIANTE = " + id;
            mod.ejecutarSQL(sql);
        }
    }
}
