using static System.Console;

namespace Gold
{
    public class GoldEngine
    {
        public void logic(bool Custom = false)
        {
            /*char[][] map = new char[4][];
            map[0] = new char[] { '#', '#', '#', '#' };
            map[1] = new char[] { '#', '.', '.', '#' };
            map[2] = new char[] { '#', '@', '.', '#' };
            map[3] = new char[] { '#', '#', '#', '#' };

            int[] pp = { 2, 1 }; //palyer position*/

            MapLoader lmap = new MapLoader();
            if (Custom)
            {
                lmap.Custom();
                lmap.load();
            }
            else
                lmap.load();

            char[][] map = lmap.map;
            int[] pp = lmap.pp;

            ConsoleKey input; //players input
            string output = ""; //output for the player
            char ns; //next space
            char ys = '.'; //your space

            Clear();

            while (true)
            {
                string[] maps = new string[map.Length];

                int i = 0;
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
                }


                /*int i = 0;
                int o = 0;
                while (i < map.Length)
                {
                    while (o < map[i].Length)
                    {
                        Write("{0}", map[i][o]);
                        o++;
                    }
                    Write("\n");
                    o = 0;
                    i++;
                }*/

                WriteLine("your position x{0},y{1}: {2}",pp[0], pp[1], ys);
                Write("#>{0}",output);
                input = ReadKey(false).Key;
                Thread.Sleep(10); //made the screen realoding better but not there is a long delay when you held the key
                if (input == ConsoleKey.UpArrow)
                {
                    output = String.Format("");
                    ns = map[pp[0] - 1][pp[1]];
                    if(ns == '.')
                    {
                        map[pp[0] - 1][pp[1]] = '@';
                        map[pp[0]][pp[1]] = '.';
                        map[pp[0]][pp[1]] = ys;
                        ys = ns;
                        pp[0] = pp[0] - 1;
                        pp[1] = pp[1];
                    }
                    else if(ns == '#')
                    {
                        output = String.Format("wall, can't walk there");
                    }
                    else
                    {
                        output = String.Format("error");
                    }
                }
                else if (input == ConsoleKey.DownArrow)
                {
                    output = String.Format("");
                    ns = map[pp[0] + 1][pp[1]];
                    if (ns == '.')
                    {
                        map[pp[0] + 1][pp[1]] = '@';
                        map[pp[0]][pp[1]] = '.';
                        map[pp[0]][pp[1]] = ys;
                        ys = ns;
                        pp[0] = pp[0] + 1;
                        pp[1] = pp[1];
                    }
                    else if (ns == '#')
                    {
                        output = String.Format("wall, can't walk there");
                    }
                    else
                    {
                        output = String.Format("error");
                    }
                }
                else if (input == ConsoleKey.RightArrow)
                {
                    output = String.Format("");
                    ns = map[pp[0]][pp[1] + 1];
                    if (ns == '.')
                    {
                        map[pp[0]][pp[1] + 1] = '@';
                        map[pp[0]][pp[1]] = '.';
                        map[pp[0]][pp[1]] = ys;
                        ys = ns;
                        pp[0] = pp[0];
                        pp[1] = pp[1] + 1;
                    }
                    else if (ns == '#')
                    {
                        output = String.Format("wall, can't walk there");
                    }
                    else
                    {
                        output = String.Format("error");
                    }
                }
                else if (input == ConsoleKey.LeftArrow)
                {
                    output = String.Format("");
                    ns = map[pp[0]][pp[1] - 1];
                    if (ns == '.')
                    {
                        map[pp[0]][pp[1] - 1] = '@';
                        map[pp[0]][pp[1]] = '.';
                        map[pp[0]][pp[1]] = ys;
                        ys = ns;
                        pp[0] = pp[0];
                        pp[1] = pp[1] - 1;
                    }
                    else if (ns == '#')
                    {
                        output = String.Format("wall, can't walk there");
                    }
                    else
                    {
                        output = String.Format("error");
                    }
                }
                else if(input == ConsoleKey.Q)
                {
                    Clear();
                    break;
                }
                else
                {
                    output = String.Format("error");
                }
                //Clear(); // clearly not a flicker free engine
                FlickerFreeClear();
            }
        }
        void FlickerFreeClear()
        {
            int height = WindowHeight;
            int width = WindowWidth;
            for (int y = 0; y < height; y++)
            {
                SetCursorPosition(0, y);
                Write(new string(' ', width));
            }
            SetCursorPosition(0, 0); //reset cursor
        }
    }
}
