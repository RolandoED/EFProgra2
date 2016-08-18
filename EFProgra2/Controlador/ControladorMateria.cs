using System.Data;


namespace EFProgra2
{
    class ControladorMateria
    {
        
        Modelo mod = new Modelo();
        EntidadProfesor entidad = new EntidadProfesor();
        string sql;

        public DataTable leer()
        {
            sql = "SELECT "
                + "ID_PROFESOR AS Cedula,"
                + "NOMBRE AS Nombre,"
                + "APELLIDO AS Apellido "
                + " FROM "
                + "PROFESOR";
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
        
        public void insertar(EntidadProfesor entidad)
        {
            sql = "INSERT INTO PROFESOR ("
                + "ID_PROFESOR,"
                + "NOMBRE,"
                + "APELLIDO "
                + ") VALUES ("
                + entidad.Cedula + ","
                + "'" + entidad.Nombre + "',"
                + "'" + entidad.Apellido + "'"
                + ")";
            mod.ejecutarSQL(sql);
        }

        public void modificar(EntidadProfesor entidad)
        {
            sql = "UPDATE PROFESOR SET "
                + "NOMBRE ='" + entidad.Nombre + "',"
                + "APELLIDO = '" + entidad.Apellido + "' "
                + " WHERE "
                + " ID_PROFESOR = " + entidad.Cedula;
            mod.ejecutarSQL(sql);
        }

        public void eliminar(int id)
        {
            sql = "DELETE PROFESOR "
                + "WHERE "
                + "ID_PROFESOR = " + id;
            mod.ejecutarSQL(sql);
        }
    }
}
