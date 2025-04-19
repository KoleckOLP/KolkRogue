using Gneo;
using Gnew;
using Gold;
using System.Reflection;
using static System.Console;


namespace Launcher
{
    internal class Menu
    {
        private readonly string name;
        private readonly string ver;
        private readonly string year;
        private readonly string date;
        private readonly IMapLoaderService mapLoader;
        private readonly GneoEngine gneoEngine;
        private readonly GnewEngine gnewEngine;
        private readonly GoldEngine goldEngine;
        private readonly bool isAlphaVersion = true;

        public Menu()
        {
            var assembly = Assembly.GetEntryAssembly()!;
            name = assembly.GetName().Name!;
            ver = assembly.GetName().Version!.ToString();
            year = DateTime.Now.Year.ToString();
            date = AssemblyInfo.Date.ToString("dd.MM.yyyy");
            gneoEngine = new GneoEngine();
            mapLoader = new MapLoader();
            gnewEngine = new GnewEngine(mapLoader);
            goldEngine = new GoldEngine();

        }

        public void ShowMenu()
        {
            Clear();
            while (true)
            {
                WriteLine(@"       _  __     _ _    ____                             ");
                WriteLine(@"      | |/ /___ | | | _|  _ \ ___   __ _ _   _  ___      ");
                WriteLine(@"      | ' // _ \| | |/ / |_) / _ \ / _` | | | |/ _ \     ");
                WriteLine(@"      | . \ (_) | |   <|  _ < (_) | (_| | |_| |  __/     ");
                WriteLine(@"      |_|\_\___/|_|_|\_\_| \_\___/ \__, |\__,_|\___|     ");
                WriteLine(@"                                    |___/                ");

                SetCursorPosition(0, 5); // writing the version into the logo without malfoming it in the code
                WriteLine($"           v{ver}{(isAlphaVersion ? " Alpha" : "")}");

                WriteLine($"     ===============================================     ");
                WriteLine($"     |    by KoleckOLP, HorseArmored Inc (C){year}   |   ");
                WriteLine($"     ===============================================     ");
                WriteLine("                                                          ");
                WriteLine("GneoEngine (G3)   | GnewEngine (G2)   | GoldEngine (G1)   ");
                WriteLine(" 1. New Game      |  3. New Game      |  5. New Game      ");
                WriteLine(" 2. Custom Levels |  4. Custom Levels |  6. Custom Levels ");
                WriteLine("                                                          ");
                WriteLine("                     q. Quit                              ");
                SetCursorPosition(21, 15);
                Write("#");
                char choice = ReadKey().KeyChar;
                HandleMenuChoice(choice);
            }
        }

        public void HandleMenuChoice(char choice)
        {
            switch (choice)
            {
                case '1':
                    Clear();
                    gneoEngine.Test();
                    WriteLine("Gneo test called");
                    break;
                case '2':
                    Message($"         Gneo didn't start development yet.");
                    break;
                case '3':
                    Clear();
                    gnewEngine.StartGame(false);
                    WriteLine("Gnew start game (false) called");
                    break;
                case '4':
                    Clear();
                    gnewEngine.StartGame(true);
                    WriteLine("Gnew start game (true) called");
                    break;
                case '5':
                    Clear();
                    goldEngine.logic();
                    WriteLine("Gold logic called");
                    break;
                case '6':
                    Clear();
                    goldEngine.logic(true);
                    WriteLine("Gold logic (true) called");
                    break;
                case 'q':
                    Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Message($"     '{choice}' is the wrong choice, try 1-6 or q.");
                    break;
            }
        }

        static void Message(string message)
        {
            SetCursorPosition(0, 17); // error message under the input
            Write(message);
            SetCursorPosition(22, 15); // erases the character you pressed
            Write(" ");
            SetCursorPosition(0, 0); // return cursor to default pos for next draw
        }
    }
}
