using static System.Console;

namespace Launcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu mainMenu = new Menu();

            String[] argus = new string[2];

            if (Environment.GetCommandLineArgs().Length == 1)
            {
                argus[0] = Environment.GetCommandLineArgs()[0];
                argus[1] = "";
            }
            else if (Environment.GetCommandLineArgs().Length >= 2)
            {
                argus = Environment.GetCommandLineArgs();
            }

            if (argus[1] == "--help" || argus[1] == "-h" || argus[1] == "-?")
            {
                //mainMenu.ShowHelp();
                Environment.Exit(0);
            }
            else if (argus[1] == "--Gneo" || argus[1] == "--G3" || argus[1] == "-3")
            {
                mainMenu.HandleMenuChoice('1');
            }
            else if (argus[1] == "--Gnew" || argus[1] == "--G2" || argus[1] == "-2")
            {
                mainMenu.HandleMenuChoice('3');
            }
            else if (argus[1] == "--Gold" || argus[1] == "--G1" || argus[1] == "-1")
            {
                mainMenu.HandleMenuChoice('5');
            }
            else if (argus[1] == "")
            {
                mainMenu.ShowMenu();
                Environment.Exit(0);
            }
            else if (argus[1] != "")
            {
                WriteLine("Invalid argument: {0}", argus[1]);
                //mainMenu.ShowHelp();
                Environment.Exit(0);
            }
        }
    }
}