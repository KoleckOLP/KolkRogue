using System;
using static System.Console;

namespace KolkRogue
{
    internal static class Program
    {
        private static void Main()
        {
            var menu = new Menu();

            var argus = new string[2];
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
                menu.GameHelp();
                Environment.Exit(0);
            }
            else if (argus[1] == null)
            {
                menu.GameMenu();
                Environment.Exit(0);
            }
            else
            {
                WriteLine("Invalid argument: {0}", argus[1]);
                menu.GameHelp();
                Environment.Exit(0);
            }
        }
    }
}
