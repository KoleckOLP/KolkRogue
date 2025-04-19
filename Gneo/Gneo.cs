using static System.Console;

namespace Gneo
{
    public class GneoEngine
    {
        public void Editor()
        {
            Player player = new Player(new Position(8, 28));
            Trap trap1 = new Trap(new Position(5, 13));
            //b is at 9, 12

            Scenario scenario = new Scenario(player, trap1);

            ScenearioSearilizer.SaveScenario(scenario);

            Scenario? loadedScenario = ScenearioSearilizer.LoadScenario(); // also allowed to be nulleble

            if (loadedScenario != null)
            {
                WriteLine(loadedScenario);
                if (loadedScenario.Player == null)
                    WriteLine("yap null player!");
                if (loadedScenario.Traps.Count == 0)
                    WriteLine("we got no traps in this bitch.");
            }

            ReadKey();
            Clear();
        }

        public MapTile[][] map; // for Gnew
        public Scenario? sceneario; // for Gnew
        public string output; // for Gnew
        public bool gameOver; // for Gnew
        public MapTile yourSpace = MapTile.Floor; // for Gnew
        public Visibility visibility = new Visibility();

        public bool running = true;

        public void Test()
        {
            string? storyContent = MapLoader.LoadMapFromFile(); // this does load the map from a .TXT file

            if (storyContent != null)
            {
                map = TileConverter.ConvertStringToMapTileArray(storyContent); // turns the string (char array) in the map txt to MapTile array
                //TileConverter.PrintMapTileArray(map); // this does draw the whole map which we do not need.
                sceneario = ScenearioSearilizer.LoadScenario(); // loads the sceneario
                while (running)
                {
                    if (sceneario != null && sceneario.Player != null)
                    {
                        VisibilityRenderrer(map, sceneario);
                        (int bellowMapY, int bellowMapX) = GetCursorPosition();
                        Write($"{sceneario.Player.Position.X}, {sceneario.Player.Position.Y} standing on: {map[sceneario.Player.Position.Y][sceneario.Player.Position.X]} health: {sceneario.Player.Health}\n" +
                              $"#{output}");

                        PlayerMove();
                        SetCursorPosition(bellowMapY, bellowMapX);
                        Write("                                            \n" +
                              "                                            ");
                        SetCursorPosition(bellowMapY, bellowMapX);
                        Write($"{sceneario.Player.Position.X}, {sceneario.Player.Position.Y} standing on: {map[sceneario.Player.Position.Y][sceneario.Player.Position.X]} health: {sceneario.Player.Health}\n" +
                              $"#{output}");
                        SetCursorPosition(0, 0);
                    }
                }
                Clear();
            }
        }

        public void VisibilityRenderrer(MapTile[][] map, Scenario scenario)
        {
            // Define the fixed width (22 columns) and height (11 rows)
            int width = 22;
            int height = 11;

            // Calculate the player's position
            int playerX = scenario.Player.Position.X;
            int playerY = scenario.Player.Position.Y;

            // Loop over the rows (Y-axis)
            for (int y = 0; y < height; y++)
            {
                // Loop over the columns (X-axis)
                for (int x = 0; x < width; x++)
                {
                    // Calculate the map position based on the player's center position
                    int mapX = playerX - 10 + x; // 10 tiles to the left and 10 to the right
                    int mapY = playerY - 5 + y;  // 5 tiles above and 5 below the player

                    // If the current map position is out of bounds, fill with space
                    if (mapY < 0 || mapY >= map.Length || mapX < 0 || mapX >= map[mapY].Length)
                    {
                        Write(" ");  // Print a space if out of bounds
                    }
                    else
                    {
                        // If the current position matches the player's position, print the player symbol
                        if (mapX == playerX && mapY == playerY)
                        {
                            if (map[playerY][playerX] != MapTile.Air)
                                Write((char)scenario.Player.Symbol);  // Print the player's symbol
                            else
                                Write((char)MapTile.Air);
                        }
                        else
                        {
                            // Print the tile data (casting to char if MapTile is an enum)
                            Write((char)map[mapY][mapX]);
                        }
                    }
                }
                WriteLine();  // Move to the next line after printing the row
            }
        }

        public void PlayerMove()
        {
            ConsoleKey input = ReadKey(false).Key;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.NumPad8:
                    PositionChecking(-1, 0, map.Length);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.NumPad2:
                    PositionChecking(1, 0, map.Length);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad6:
                    PositionChecking(0, 1, map.Length);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.NumPad4:
                    PositionChecking(0, -1, map.Length);
                    break;
                case ConsoleKey.NumPad7:
                    PositionChecking(-1, -1, map.Length);
                    break;
                case ConsoleKey.NumPad9:
                    PositionChecking(-1, 1, map.Length);
                    break;
                case ConsoleKey.NumPad1:
                    PositionChecking(1, -1, map.Length);
                    break;
                case ConsoleKey.NumPad3:
                    PositionChecking(1, 1, map.Length);
                    break;
                case ConsoleKey.Q:
                    running = false;
                    return; // Exit the loop doesn't quit the game xD
            }
        }

        public void PositionChecking(int deltaRow, int deltaCol, int mapLength)
        {
            int newRow = sceneario.Player.Position.Y + deltaRow;
            int newCol = sceneario.Player.Position.X + deltaCol;

            bool inviztrap = false;
            string deathmessage = "";
            MapTile nextSpace = map[newRow][newCol];

            if (!gameOver)
            {
                if (nextSpace != MapTile.Wall)
                {

                    map[sceneario.Player.Position.Y][sceneario.Player.Position.X] = yourSpace;

                    sceneario.Player.Position.Y = newRow;
                    sceneario.Player.Position.X = newCol;
                    yourSpace = nextSpace;
                    output = "";
                }
                else
                {
                    output = "wall, you can't continue this way";
                }

                if (yourSpace == MapTile.Trap || inviztrap == true)
                {
                    sceneario.Player.Health -= 10;
                    output = "Ouch, you stepped in a trap";
                    deathmessage = "You got impaled on a trap. ";
                }

                if (yourSpace == MapTile.Air)
                {
                    sceneario.Player.Health = 0;
                    deathmessage = "You fell into the void. ";
                }

                if (sceneario.Player.Health <= 0)
                {
                    output = deathmessage + "You're dead!";
                    gameOver = true;
                    return;
                }
            }
        }
    }
}
