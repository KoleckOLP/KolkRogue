using System;
using System.Reflection;
using static System.Console;

namespace KolkRogue
{
    internal class Menu
    {
        private readonly string _name = Assembly.GetEntryAssembly()?.GetName().Name;
        private readonly string _ver = Assembly.GetEntryAssembly()?.GetName().Version?.ToString();
        private readonly string _year = DateTime.Now.Year.ToString();
        private readonly string _date = AssemblyInfo.Date.ToString("dd.MM.yyyy");

        public void GameMenu()
        {
            WriteLine("{0} v{1} Alpha\n" +
                      "by koleq, HorseArmored Inc (C){2}\n", _name, _ver, _year);

            while (true)
            {
                var test2 = new Gnew();


                WriteLine("1. New Game\n" +
                          "2. Custom Levels\n" +
                          "3. Load Game\n" +
                          "4. About & Credits\n" +
                          "5. Quit");
                Write("#");
                
                var choice = ReadKey().KeyChar;
                
                switch (choice)
                {
                    case '1': // New Game
                        test2.Story();
                        Clear();
                        break;
                    case '2': // Custom Levels
                        test2.Map();
                        Clear();
                        break;
                    case '3': // Load game
                        Clear();
                        WriteLine("Loading is not yet implemented\n");
                        break;
                    case '4': // About & Credits
                        Clear();
                        GameHelp();
                        break;
                    case '5': // Exit
                        Environment.Exit(0);
                        break;
                    default: // wrong input
                        Clear();
                        WriteLine("Choice is 1-4\n");
                        break;
                }

                return;
            }
        }

        public void GameHelp()
        {
            WriteLine("{0} Version: {1} Alpha by koleq, HorseArmored Inc (C){2}\n" +
                      "Built on: {3}\n" +
                      "-h, -?, --help to show this message.",_name,_ver,_year,_date);
        }
    }
}
