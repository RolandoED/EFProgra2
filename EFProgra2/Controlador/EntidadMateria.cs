namespace EFProgra2
{
    class EntidadMateria
    {
        private int id;
        private string nombre;
        private int id_profesor;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
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

        public int Id_Profesor
        {
            get
            {
                return id_profesor;
            }
            set
            {
                id_profesor = value;
            }
        }
        //CONTRUCTOR
        public EntidadMateria()
        {
            Id = int.MinValue;
            nombre = string.Empty;
            id_profesor = int.MinValue;
        }
    }
}
