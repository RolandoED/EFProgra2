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

            Console.WriteLine("Ingrese 1 si desea ejecutar los forms");
            Console.WriteLine("        2 si desea ejecutar el de consola");
            Console.WriteLine("        (cualquier otro para salir)");
            //decision = Console.ReadLine();
            decision = "1";
            EstadisticaColegio s = new EstadisticaColegio();
            Console.WriteLine(s.GENERAR());
            Console.WriteLine("Mayor 18: " + s.Mayor18());
            Console.WriteLine("Menor 18: " + s.Menor18());
            s.ContadorPorMateria();
           

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

            }
            //SALIR
            else
                Environment.Exit(0);
        }
    }
}
