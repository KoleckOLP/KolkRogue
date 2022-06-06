using System;
using static System.Console;

namespace KolkRogue
{
    internal class Gnew
    {
        public void Story()
        {
            var lmap = new MapLoader();
            lmap.Load();
            _map = lmap.Fmap;
            _pp = lmap.Fpp;
            Logic();
        }

        public void Map()
        {
            MapLoader lmap = new MapLoader();
            lmap.Custom();
            lmap.Load();
            _map = lmap.Fmap;
            _pp = lmap.Fpp;
            Logic();
        }

        private char[][] _map;
        private int[] _pp;

        private void Logic()
        {
            var maps = new string[_map.Length];

            string output = ""; //output for the player
            char ys = '.'; //your space

            int i = 0;
            while (i < _map.Length)
            {
                maps[i] = new string(_map[i]);
                i++;
            }

            Clear();
            WriteLine("arrow keys to move around, q - quit to menu");

            i = 0;
            while (i < _map.Length)
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
                      "#>{3}", _pp[0], _pp[1], ys, output);
                var input = ReadKey(false).Key; //players input
                char ns; //next space
                if (input == ConsoleKey.UpArrow || input == ConsoleKey.NumPad8) //up
                {
                    ns = _map[_pp[0] - 1][_pp[1]];
                    if (ns != '#')
                    {
                        output = "";
                        _map[_pp[0] - 1][_pp[1]] = '@';
                        SetCursorPosition(_pp[1], _pp[0]);
                        Write("@");
                        _map[_pp[0]][_pp[1]] = ys;
                        SetCursorPosition(_pp[1], _pp[0]+1);
                        Write("{0}",ys);
                        _pp[0] = _pp[0] - 1;
                        _pp[1] = _pp[1];
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.DownArrow || input == ConsoleKey.NumPad2) //down
                {
                    ns = _map[_pp[0] + 1][_pp[1]];
                    if (ns != '#')
                    {
                        output = "";
                        _map[_pp[0] + 1][_pp[1]] = '@';
                        SetCursorPosition(_pp[1], _pp[0] + 2);
                        Write("@");
                        _map[_pp[0]][_pp[1]] = ys;
                        SetCursorPosition(_pp[1], _pp[0]+1);
                        Write("{0}", ys);
                        _pp[0] = _pp[0] + 1;
                        _pp[1] = _pp[1];
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.RightArrow || input == ConsoleKey.NumPad6) //right
                {
                    ns = _map[_pp[0]][_pp[1] + 1];
                    if (ns != '#')
                    {
                        output = "";
                        _map[_pp[0]][_pp[1] + 1] = '@';
                        SetCursorPosition(_pp[1] + 1, _pp[0]+1);
                        Write("@");
                        _map[_pp[0]][_pp[1]] = ys;
                        SetCursorPosition(_pp[1],_pp[0]+1);
                        Write("{0}", ys);
                        _pp[0] = _pp[0];
                        _pp[1] = _pp[1] + 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.LeftArrow || input == ConsoleKey.NumPad4) //left
                {
                    ns = _map[_pp[0]][_pp[1] - 1];
                    if (ns != '#')
                    {
                        output = "";
                        _map[_pp[0]][_pp[1] - 1] = '@';
                        SetCursorPosition(_pp[1] - 1, _pp[0] + 1);
                        Write("@");
                        _map[_pp[0]][_pp[1]] = ys;
                        SetCursorPosition(_pp[1], _pp[0] + 1);
                        Write("{0}", ys);
                        _pp[0] = _pp[0];
                        _pp[1] = _pp[1] - 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.NumPad7) //Up-Left
                {
                    ns = _map[_pp[0] - 1][_pp[1] - 1]; //collision detection
                    if (ns != '#')
                    {
                        output = "";
                        _map[_pp[0] - 1][_pp[1] - 1] = '@';
                        SetCursorPosition(_pp[1] - 1, _pp[0]); //game renderer
                        Write("@");
                        _map[_pp[0]][_pp[1]] = ys;
                        SetCursorPosition(_pp[1], _pp[0] + 1); //game renderer
                        Write("{0}", ys);
                        _pp[0] = _pp[0] - 1;
                        _pp[1] = _pp[1] - 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.NumPad9) //Up-Right
                {
                    ns = _map[_pp[0] - 1][_pp[1] + 1];
                    if (ns != '#')
                    {
                        output = "";
                        _map[_pp[0] - 1][_pp[1] + 1] = '@';
                        SetCursorPosition(_pp[1] + 1, _pp[0]); //game renderer
                        Write("@");
                        _map[_pp[0]][_pp[1]] = ys;
                        SetCursorPosition(_pp[1], _pp[0] + 1); //game renderer
                        Write("{0}", ys);
                        _pp[0] = _pp[0] - 1;
                        _pp[1] = _pp[1] + 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.NumPad1) //Down-Left
                {
                    ns = _map[_pp[0] + 1][_pp[1] - 1];
                    if (ns != '#')
                    {
                        output = "";
                        _map[_pp[0] + 1][_pp[1] - 1] = '@';
                        SetCursorPosition(_pp[1] - 1, _pp[0] + 2); //game renderer
                        Write("@");
                        _map[_pp[0]][_pp[1]] = ys;
                        SetCursorPosition(_pp[1], _pp[0] + 1); //game renderer
                        Write("{0}", ys);
                        _pp[0] = _pp[0] + 1;
                        _pp[1] = _pp[1] - 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
                    }
                }
                if (input == ConsoleKey.NumPad3) //Down-Left
                {
                    ns = _map[_pp[0] + 1][_pp[1] + 1];
                    if (ns != '#')
                    {
                        output = "";
                        _map[_pp[0] + 1][_pp[1] + 1] = '@';
                        SetCursorPosition(_pp[1] + 1, _pp[0] + 2); //game renderer
                        Write("@");
                        _map[_pp[0]][_pp[1]] = ys;
                        SetCursorPosition(_pp[1], _pp[0] + 1); //game renderer
                        Write("{0}", ys);
                        _pp[0] = _pp[0] + 1;
                        _pp[1] = _pp[1] + 1;
                        ys = ns;
                    }
                    else if (ns == '#')
                    {
                        output = "wall, you can't continue this way";
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
