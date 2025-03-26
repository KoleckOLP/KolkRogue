using System;
using System.Reflection;
using static System.Console;

namespace KolkRogue
{
    class Menu
    {
        private readonly string name;
        private readonly string ver;
        private readonly string year;
        private readonly string date;
        private readonly IMapLoaderService mapLoader;
        private readonly Gnew gameInstance;
        private readonly bool isAlphaVersion = true;

        public Menu()
        {
            var assembly = Assembly.GetEntryAssembly();
            name = assembly.GetName().Name.ToString();
            ver = assembly.GetName().Version.ToString();
            year = DateTime.Now.Year.ToString();
            date = AssemblyInfo.Date.ToString("dd.MM.yyyy");
            mapLoader = new MapLoader();
            gameInstance = new Gnew(mapLoader);
        }

        public void ShowMenu()
        {
            WriteLine($"{name} v{ver}{(isAlphaVersion ? " Alpha" : "")} by KoleckOLP, HorseArmored Inc (C){year}\n");

            while (true)
            {
                WriteLine("1. New Game\n" +
                          "2. Custom Levels\n" +
                          "3. Load Game\n" +
                          "4. About & Credits\n" +
                          "5. Quit");
                Write("#");
                char choice = ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        gameInstance.StartGame(false);
                        Clear();
                        break;
                    case '2':
                        gameInstance.StartGame(true);
                        Clear();
                        break;
                    case '3':
                        Clear();
                        WriteLine("Loading is not yet implemented\n");
                        break;
                    case '4':
                        Clear();
                        ShowHelp();
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;
                    default:
                        Clear();
                        WriteLine("Choice is 1-5\n");
                        break;
                }
            }
        }

        public void ShowHelp()
        {
            WriteLine($"{name} version: {ver} {year} by KoleckOLP, HorseArmored Inc (C){(isAlphaVersion ? " Alpha" : "")}\n" +
                      $"Built on: {date}");
        }
    }
}