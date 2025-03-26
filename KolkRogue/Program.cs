using System;
using static System.Console;

namespace KolkRogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu mainMenu = new Menu();

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
                mainMenu.ShowHelp();
                Environment.Exit(0);
            }
            else if (argus[1] == null)
            {
                mainMenu.ShowMenu();
                Environment.Exit(0);
            }
            else
            {
                WriteLine("Invalid argument: {0}", argus[1]);
                mainMenu.ShowHelp();
                Environment.Exit(0);
            }
        }
    }
}
