using System;
using static System.Console;

namespace KolkRogue
{
    class Gnew
    {
        private readonly IMapLoaderService _mapLoader;
        private char[][] map;
        private Player player;

        public Gnew(IMapLoaderService mapLoader)
        {
            _mapLoader = mapLoader;
        }

        public void StartGame(bool custom = false, string levelName = "lvl1")
        {
            (map, player) = _mapLoader.LoadMap(custom, levelName);
            if (map != null && player != null)
            {
                Logic();
            }
        }

        public void Logic()
        {
            string[] maps = new string[map.Length];

            string output = "";
            char yourSpace = '.';

            for (int i = 0; i < map.Length; i++)
            {
                maps[i] = new string(map[i]);  // Convert each char[] to a string
            }

            Clear(); // important screen clean to overwrite the menu
            WriteLine("arrow keys to move around, q - quit to menu"); // the frist line of the game

            foreach (var row in maps)
            {
                WriteLine(row);
            }

            bool gameOver = false;

            void MovePlayer(int deltaRow, int deltaCol, int mapLength)
            {
                int newRow = player.Row + deltaRow;
                int newCol = player.Col + deltaCol;
                char nextSpace = map[newRow][newCol];
                if (!gameOver)
                {
                    if (nextSpace != '#')
                    {
                        map[newRow][newCol] = '@';
                        SetCursorPosition(newCol, newRow + 1);
                        Write("@");

                        map[player.Row][player.Col] = yourSpace;
                        SetCursorPosition(player.Col, player.Row + 1);
                        Write("{0}", yourSpace);

                        player.Row = newRow;
                        player.Col = newCol;
                        yourSpace = nextSpace;
                        output = "";
                    }
                    else
                    {
                        output = "wall, you can't continue this way";
                    }

                    if (yourSpace == 'T')
                    {
                        player.Health -= 10;
                        output = "Ouch, you stepped in a trap";
                    }

                    if (player.Health <= 0)
                    {
                        output = "You're dead!";
                        gameOver = true;
                        return;
                    }
                }
            }

            while (true)
            {
                SetCursorPosition(0, maps.Length + 1);
                Write($"                                                                                                \n" +
                      $"                                                                                                ");
                SetCursorPosition(0, maps.Length + 1);
                Write($"{player.Row}, {player.Col} standing on: {yourSpace} health: {player.Health}\n" +
                      $"#>{output}");

                ConsoleKey input = ReadKey(false).Key;

                switch (input)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.NumPad8:
                        MovePlayer(-1, 0, maps.Length);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.NumPad2:
                        MovePlayer(1, 0, maps.Length);
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.NumPad6:
                        MovePlayer(0, 1, maps.Length);
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.NumPad4:
                        MovePlayer(0, -1, maps.Length);
                        break;
                    case ConsoleKey.NumPad7:
                        MovePlayer(-1, -1, maps.Length);
                        break;
                    case ConsoleKey.NumPad9:
                        MovePlayer(-1, 1, maps.Length);
                        break;
                    case ConsoleKey.NumPad1:
                        MovePlayer(1, -1, maps.Length);
                        break;
                    case ConsoleKey.NumPad3:
                        MovePlayer(1, 1, maps.Length);
                        break;
                    case ConsoleKey.Q:
                        return; // Exit the loop
                }
            }
        }
    }
}
