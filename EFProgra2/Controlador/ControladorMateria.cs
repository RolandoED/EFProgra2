using System.Data;


namespace EFProgra2
{
    class ControladorMateria
    {
        
        Modelo mod = new Modelo();
        EntidadMateria entidad = new EntidadMateria();
        string sql;

        public DataTable leer()
        {
            sql = "SELECT "
                + "ID_materia AS ID,"
                + "NOMBRE AS Nombre,"
                + "ID_PROFESOR AS ID_PROF "
                + " FROM "
                + "MATERIA";
            return mod.llenarDT(sql);
        }

        public DataTable buscar(int id)
        {
            sql = "SELECT "
                + "NOMBRE AS Nombre,"
                + "ID_PROFESOR AS IDPROF"
                + " FROM "
                + "MATERIA"
                + " WHERE "
                + "ID_MATERIA = " + id;
            return mod.llenarDT(sql);
        }
        
        public void insertar(EntidadMateria entidad)
        {
            sql = "INSERT INTO MATERIA ("
                + "ID_MATERIA,"
                + "NOMBRE,"
                + "ID_PROFESOR "
                + ") VALUES ("
                + entidad.Id + ","
                + "'" + entidad.Nombre + "',"
                + "'" + entidad.Id_Profesor + "'"
                + ")";
            mod.ejecutarSQL(sql);
        }

        public void modificar(EntidadMateria entidad)
        {
            sql = "UPDATE MATERIA SET "
                + "NOMBRE ='" + entidad.Nombre + "',"
                + "ID_PROFESOR = " + entidad.Id_Profesor + " "
                + " WHERE "
                + " ID_MATERIA = " + entidad.Id;
            mod.ejecutarSQL(sql);
        }

        public void eliminar(int id)
        {
            sql = "DELETE MATERIA "
                + "WHERE "
                + "ID_MATERIA = " + id;
            mod.ejecutarSQL(sql);
        }
    }
}
