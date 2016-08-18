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
        static void Main(string[] args)
        {
            string decision = "";

            Console.WriteLine("Ingrese 1 si desea ejecutar los forms");
            Console.WriteLine("        2 si desea ejecutar el de consola");
            Console.WriteLine("        (cualquier otro para salir)");
            //decision = Console.ReadLine();
            decision = "1";

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
