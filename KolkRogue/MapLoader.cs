using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Console;

namespace KolkRogue
{
    internal class MapLoader
    {
        public readonly int[] Fpp = new int[2];
        public char[][] Fmap;

        private string _lvln = "lvl1";

        public void Custom()
        {
            Write("\ntype name of Custom level you want to load:");
            _lvln = ReadLine();
        }
        
        public void Load()
        {
            var path = (Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location));

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                path = $"{path}/levels/{_lvln}.txt";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                path = $"{path}/levels/{_lvln}.txt";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                path = $"{path}\\levels\\{_lvln}.txt";
            }

            if (!File.Exists(path))
            {
                WriteLine("Cannot load no map with that name");
            }

            if (path != null)
            {
                string[] maps = File.ReadAllLines(path);

                char[][] map = new char[maps.Length][];
                this.Fmap = map;

                int i = 0;
                foreach (string unused in maps)
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
                            this.Fpp[0] = i;
                            this.Fpp[1] = o;
                        }
                        o++;
                    }
                    o = 0;
                    i++;
                }
            }
        }
    }
}
