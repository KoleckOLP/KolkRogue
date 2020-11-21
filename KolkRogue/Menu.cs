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
    class Menu
    {
        private string name = Assembly.GetEntryAssembly().GetName().Name.ToString();
        private string ver = Assembly.GetEntryAssembly().GetName().Version.ToString();
        private string year = DateTime.Now.Year.ToString();
        private string date = KolkRogue.AssemblyInfo.Date.ToString("dd.MM.yyyy");

        public void menu()
        {
            WriteLine("{0} v{1}Alpha\n" +
                      "by KoleckOLP, HorseArmored Inc (C){2}\n", name, ver, year);

            while (true)
            {
                Gnew test2 = new Gnew();

                char choice;


                WriteLine("1. New Game\n" +
                          "2. Custom Levels\n" +
                          "3. Load Game\n" +
                          "4. About & Credits\n" +
                          "5. Quit");
                Write("#");
                choice = ReadKey().KeyChar;
                if (choice == '1')
                {
                    test2.Story();
                    Clear();
                }
                else if (choice == '2')
                {
                    test2.Map();
                    Clear();
                }
                else if (choice == '3')
                {
                    Clear();
                    WriteLine("Loading is not yet implemented\n");
                }
                else if (choice == '4')
                {
                    Clear();
                    help();
                }
                else if (choice == '5')
                {
                    Environment.Exit(0);
                }
                else
                {
                    Clear();
                    WriteLine("Chice is 1-4\n");
                }
            }
        }

        public void help()
        {
            WriteLine("{0} vesion: {1} Alpha by KoleckOLP, HorseArmored Inc (C){2}\n" +
                      "Builded on: {3}\n" +
                      "-h, -?, --help to show this message.",name,ver,year,date);
        }
    }
}
