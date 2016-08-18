namespace EFProgra2
{
    class EntidadProfesor
    {
        private int cedula;
        private string nombre;
        private string apellido;

        public int Cedula
        {
            get
            {
                return cedula;
            }
            set
            {
                cedula = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = value;
            }
        }
        //CONTRUCTOR
        public EntidadProfesor()
        {
            cedula = int.MinValue;
            nombre = string.Empty;
            apellido = string.Empty;
        }
    }
}
