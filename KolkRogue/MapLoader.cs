using System;
using System.IO;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Console;

namespace KolkRogue
{
    class MapLoader
    {
        public int[] pp = new int[2];
        public char[][] map;

        public string lvln = "lvl1";

        public void Custom()
        {
            Write("\ntype name of Custom level you want to load:");
            lvln = ReadLine();
        }


        public void load()
        {
            string path = (Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                path = String.Format("{0}/{1}.txt", path, lvln);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                path = String.Format("{0}/{1}.txt", path, lvln);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                path = String.Format("{0}\\{1}.txt", path, lvln);
            }

            if (!File.Exists(path))
            {
                WriteLine("Cannot load no map with that name");
            }

            string[] maps = File.ReadAllLines(path);

            char[][] map = new char[maps.Length][];
            this.map = map;

            int i = 0;
            foreach (string s in maps)
            {
                map[i] = maps[i].ToCharArray();
                i++;
            }

            i = 0;
            int o = 0;
            while (i < map.Length)
            {
                while (o < map[i].Length)
                {
                    if (map[i][o] == '@')
                    {
                        this.pp[0] = i;
                        this.pp[1] = o;
                    }
                    o++;
                }
                o = 0;
                i++;
            }
        }
    }
}
