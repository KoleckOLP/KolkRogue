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
    class Gnew
    {
        public void Story()
        {
            MapLoader lmap = new MapLoader();
            lmap.load();
            map = lmap.map;
            pp = lmap.pp;
            logic();
        }

        public void Map()
        {
            MapLoader lmap = new MapLoader();
            lmap.Custom();
            lmap.load();
            map = lmap.map;
            pp = lmap.pp;
            logic();
        }

        private char[][] map;
        private int[] pp;
        public void logic()
        {
            string[] maps = new string[map.Length];

            ConsoleKey input; //players input
            string output = ""; //output for the player
            char ns; //next space
            char ys = '.'; //your space

            int i = 0;
            while (i < map.Length)
            {
                maps[i] = new string(map[i]);
                i++;
            }

            Clear();
            WriteLine("arrow keys to move around, q - quit to menu");

            i = 0;
            while (i < map.Length)
            {
                WriteLine("{0}", maps[i]);
                i++;
            }

            while(true)
            {
                

                SetCursorPosition(0,maps.Length+1);
                Write("                                                                              \n" +
                      "                                                                              ");
                SetCursorPosition(0, maps.Length+1);
                Write("{0}, {1} standing on: {2}\n" +
                      "#>{3}", pp[0], pp[1], ys, output);
                input = ReadKey(false).Key;
                if (input == ConsoleKey.UpArrow || input == ConsoleKey.NumPad8) //up
                {
                    ns = map[pp[0] - 1][pp[1]];
                    if (ns != '#')
                    {
                        output = "";
                        map[pp[0] - 1][pp[1]] = '@';
                        SetCursorPosition(pp[1], pp[0]);
                        Write("@");
                        map[pp[0]][pp[1]] = ys;
                        SetCursorPosition(pp[1], pp[0]+1);
                        Write("{0}",ys);
                        pp[0] = pp[0] - 1;
                        pp[1] = pp[1];
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.DownArrow || input == ConsoleKey.NumPad2) //down
                {
                    ns = map[pp[0] + 1][pp[1]];
                    if (ns != '#')
                    {
                        output = "";
                        map[pp[0] + 1][pp[1]] = '@';
                        SetCursorPosition(pp[1], pp[0] + 2);
                        Write("@");
                        map[pp[0]][pp[1]] = ys;
                        SetCursorPosition(pp[1], pp[0]+1);
                        Write("{0}", ys);
                        pp[0] = pp[0] + 1;
                        pp[1] = pp[1];
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.RightArrow || input == ConsoleKey.NumPad6) //right
                {
                    ns = map[pp[0]][pp[1] + 1];
                    if (ns != '#')
                    {
                        output = "";
                        map[pp[0]][pp[1] + 1] = '@';
                        SetCursorPosition(pp[1] + 1, pp[0]+1);
                        Write("@");
                        map[pp[0]][pp[1]] = ys;
                        SetCursorPosition(pp[1],pp[0]+1);
                        Write("{0}", ys);
                        pp[0] = pp[0];
                        pp[1] = pp[1] + 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.LeftArrow || input == ConsoleKey.NumPad4) //left
                {
                    ns = map[pp[0]][pp[1] - 1];
                    if (ns != '#')
                    {
                        output = "";
                        map[pp[0]][pp[1] - 1] = '@';
                        SetCursorPosition(pp[1] - 1, pp[0] + 1);
                        Write("@");
                        map[pp[0]][pp[1]] = ys;
                        SetCursorPosition(pp[1], pp[0] + 1);
                        Write("{0}", ys);
                        pp[0] = pp[0];
                        pp[1] = pp[1] - 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall"; output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.NumPad7) //Up-Left
                {
                    ns = map[pp[0] - 1][pp[1] - 1]; //cosision detection
                    if (ns != '#')
                    {
                        output = "";
                        map[pp[0] - 1][pp[1] - 1] = '@';
                        SetCursorPosition(pp[1] - 1, pp[0]); //game renderer
                        Write("@");
                        map[pp[0]][pp[1]] = ys;
                        SetCursorPosition(pp[1], pp[0] + 1); //game renderer
                        Write("{0}", ys);
                        pp[0] = pp[0] - 1;
                        pp[1] = pp[1] - 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall"; output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.NumPad9) //Up-Right
                {
                    ns = map[pp[0] - 1][pp[1] + 1];
                    if (ns != '#')
                    {
                        output = "";
                        map[pp[0] - 1][pp[1] + 1] = '@';
                        SetCursorPosition(pp[1] + 1, pp[0]); //game renderer
                        Write("@");
                        map[pp[0]][pp[1]] = ys;
                        SetCursorPosition(pp[1], pp[0] + 1); //game renderer
                        Write("{0}", ys);
                        pp[0] = pp[0] - 1;
                        pp[1] = pp[1] + 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall"; output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.NumPad1) //Down-Left
                {
                    ns = map[pp[0] + 1][pp[1] - 1];
                    if (ns != '#')
                    {
                        output = "";
                        map[pp[0] + 1][pp[1] - 1] = '@';
                        SetCursorPosition(pp[1] - 1, pp[0] + 2); //game renderer
                        Write("@");
                        map[pp[0]][pp[1]] = ys;
                        SetCursorPosition(pp[1], pp[0] + 1); //game renderer
                        Write("{0}", ys);
                        pp[0] = pp[0] + 1;
                        pp[1] = pp[1] - 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall"; output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.NumPad3) //Down-Left
                {
                    ns = map[pp[0] + 1][pp[1] + 1];
                    if (ns != '#')
                    {
                        output = "";
                        map[pp[0] + 1][pp[1] + 1] = '@';
                        SetCursorPosition(pp[1] + 1, pp[0] + 2); //game renderer
                        Write("@");
                        map[pp[0]][pp[1]] = ys;
                        SetCursorPosition(pp[1], pp[0] + 1); //game renderer
                        Write("{0}", ys);
                        pp[0] = pp[0] + 1;
                        pp[1] = pp[1] + 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall"; output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.Q)
                {
                    break;
                }

                //debug code!
                /*SetCursorPosition(0, maps.Length+3);
                i = 0;
                while (i < map.Length)
                {
                    maps[i] = new string(map[i]);
                    i++;
                }
                i = 0;
                while (i < map.Length)
                {
                    WriteLine("{0}", maps[i]);
                    i++;
                }*/
            }
        }
    }
}
