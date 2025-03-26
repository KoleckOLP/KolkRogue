using System;
using System.IO;
using System.Reflection;

namespace KolkRogue
{
    public interface IMapLoaderService
    {
        (char[][] map, Player player) LoadMap(bool custom = false, string levelName = "lvl1");
    }

    class MapLoader : IMapLoaderService
    {
        public (char[][] map, Player player) LoadMap(bool custom = false, string levelName = "lvl1")
        {
            if (custom)
            {
                Console.Write("\nType name of custom level you want to load: ");
                levelName = Console.ReadLine();
            }

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"{levelName}.txt");

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Cannot load map: {levelName}. File not found.");
            }

            string[] mapLines = File.ReadAllLines(path);
            char[][] map = new char[mapLines.Length][];

            for (int i = 0; i < mapLines.Length; i++)
            {
                map[i] = mapLines[i].ToCharArray();
            }

            Player player = null;
            bool playerFound = false;

            for (int i = 0; i < map.Length && !playerFound; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '@')
                    {
                        player = new Player(i, j);
                        playerFound = true;
                        break;
                    }
                }
            }

            if (!playerFound)
            {
                Console.WriteLine("Player position not found on the map.");
            }

            return (map, player);
        }
    }
}