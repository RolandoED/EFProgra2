﻿namespace EFProgra2
{
    class EntidadEstudiante
    {
        private int id_estudiante;
        private string nombre;
        private string apellido;
        private string direccion;
        private int edad;
        private int id_materia;

        public int Id_Estudiante
        {
            get
            {
                return id_estudiante;
            }
            set
            {
                id_estudiante = value;
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

        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }

        public int Edad
        {
            get
            {
                return edad;
            }
            set
            {
                edad = value;
            }
        }

        public int Id_Materia
        {
            get
            {
                return id_materia;
            }
            set
            {
                id_materia = value;
            }
        }
        //CONTRUCTOR
        public EntidadEstudiante()
        {
            id_estudiante = int.MinValue;
            nombre = string.Empty;
            apellido = string.Empty;
            direccion = string.Empty;
            edad = int.MinValue;
            id_materia = int.MinValue;                    
        }

    }
}
