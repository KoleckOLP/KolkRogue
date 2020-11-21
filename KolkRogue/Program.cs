using System;
using System.IO;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Console;
using System.Threading;

namespace KolkRogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootApp = Assembly.GetEntryAssembly().GetName().CodeBase.ToString();
            Menu menu = new Menu();
            Gnew test2 = new Gnew();
            MapLoader mapl = new MapLoader();

            String[] argus = new string[2];
            if (Environment.GetCommandLineArgs().Length == 1)
            {
                argus[0] = Environment.GetCommandLineArgs()[0];
                argus[1] = null;
            }
            else if (Environment.GetCommandLineArgs().Length == 2)
            {
                argus = Environment.GetCommandLineArgs();
            }

            if (argus[1] == "--help" || argus[1] == "-h" || argus[1] == "-?")
            {
                menu.help();
                Environment.Exit(0);
            }
            else if (argus[1] == null)
            {
                menu.menu();
                Environment.Exit(0);
            }
            else
            {
                WriteLine("Neplatný argument: {0}", argus[1]);
                menu.help();
                Environment.Exit(0);
            }
        }
    }
}
