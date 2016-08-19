using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EFProgra2
{
    class Program
    {

        [STAThread]

        ////CLASS MAIN
        static void Main(string[] args)
        {
            string decision = "";
            EstadisticaColegio entidadcolegio = new EstadisticaColegio();

            Console.WriteLine("Ingrese 1 si desea ejecutar los forms");
            Console.WriteLine("        2 si desea ejecutar el de consola");
            Console.WriteLine("        (cualquier otro para salir)");
            decision = Console.ReadLine();
            //decision = "2";

           
            //ABRIR MAIN
            if (decision.Equals("1"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MENU());
            }

            //COMENZAR LOGICA DE CONSOLA
            else if (decision.Equals("2"))
            {
                string decision2 = "";

                while (true)
                {
                    Console.WriteLine("Ingrese 1 para Generar");
                    Console.WriteLine("        2 para Mostrar");
                    Console.WriteLine("        3 para Imprimir");
                    decision2 = Console.ReadLine();
                    //GENERAR
                    if (decision2.Equals("1"))
                    {
                          entidadcolegio.GENERAR();                        
                    }
                    else if (decision2.Equals("2")) 
                    {
                        if (entidadcolegio.IsReporteEmpty())
                        {
                            Console.WriteLine("NO SE HA GENERADO REPORTE");
                        }
                        else
                            Console.WriteLine(entidadcolegio.MOSTRAR());
                    }
                    else if (decision2.Equals("3")) 
                    {
                        Console.WriteLine("Imprimir");
                    }
                }

                //Console.WriteLine("Mayor 18: " + s.Mayor18());
                //Console.WriteLine("Menor 18: " + s.Menor18());
                //s.ContadorPorMateria();
                //s.ContadorEstudiantesPorProfesor();
                //s.Profesorado();
                //s.Laboratorio();


                //STOP
                
            }
            //SALIR
            else
                Environment.Exit(0);
        }
    }
}
