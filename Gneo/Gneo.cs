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

        public MapTile[,] map; // for Gnew
        public Scenario? loadedScenario; // for Gnew
        public string output; // for Gnew
        public bool gameOver; // for Gnew
        public MapTile yourSpace = MapTile.Floor; // for Gnew

        public void Test()
        {
            string? storyContent = LoadStoryFromFile();

            if (storyContent != null)
            {
                //WriteLine(storyContent);
                WriteLine("Forward ported Gnew renderer and colision detection to Gneo Sceneario loader."); // FIX: TODO: this is here to patch Gnew forwart ported engine
                map = TileConverter.ConvertStringToMapTileArray(storyContent);
                TileConverter.PrintMapTileArray(map);
                loadedScenario = ScenearioSearilizer.LoadScenario("./Story/scenario.json");
                if (loadedScenario != null)
                {
                    if (loadedScenario.Player != null)
                    {
                        WriteLine($"Player start position: {loadedScenario.Player.Position.X.ToString()}, {loadedScenario.Player.Position.Y.ToString()}");
                        SetCursorPosition(loadedScenario.Player.Position.Y, loadedScenario.Player.Position.X + 1);
                        Write((char)MapTile.Player);
                        SetCursorPosition(0, 16);
                    }

                    if (loadedScenario.Traps.Count > 0)
                    {
                        for (int i = 0; i < loadedScenario.Traps.Count; i++)
                        {
                            WriteLine($"Trap {i} position: {loadedScenario.Traps[i].Position.X}, {loadedScenario.Traps[i].Position.Y}");
                            SetCursorPosition(loadedScenario.Traps[i].Position.Y, loadedScenario.Traps[i].Position.X + 1);
                            Write((char)loadedScenario.Traps[i].Symbol);
                            SetCursorPosition(0, 17+i);
                        }
                    }
                }

                GameplayGnewForwardPort();

                //ReadKey();
                //Clear();
            }
            else
            {
                WriteLine("Story loading failed.");
            }
        }

        // FIX: TODO: THIS CODE IS TERRIBLE DO A REWRITE YOU LAZY PIECE OF SHIT
        public void GameplayGnewForwardPort()
        {
            if (loadedScenario != null && loadedScenario.Player != null)
            {
                while (true)
                {
                    //SetCursorPosition(0, map.Length + 1);
                    SetCursorPosition(0, 20);
                        Write($"                                                                                                \n" +    
                              $"                                                                                                ");
                    //SetCursorPosition(0, map.Length + 1);
                    SetCursorPosition(0, 20);
                    WriteLine($"{loadedScenario.Player.Position.X}, {loadedScenario.Player.Position.Y} standing on: {yourSpace} health: {loadedScenario.Player.Health}\n" +
                            $"#>{output}");

                    ConsoleKey input = ReadKey(false).Key;

                    switch (input)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.NumPad8:
                            MovePlayerGnew(-1, 0, map.Length);
                            break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.NumPad2:
                            MovePlayerGnew(1, 0, map.Length);
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.NumPad6:
                            MovePlayerGnew(0, 1, map.Length);
                            break;
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.NumPad4:
                            MovePlayerGnew(0, -1, map.Length);
                            break;
                        case ConsoleKey.NumPad7:
                            MovePlayerGnew(-1, -1, map.Length);
                            break;
                        case ConsoleKey.NumPad9:
                            MovePlayerGnew(-1, 1, map.Length);
                            break;
                        case ConsoleKey.NumPad1:
                            MovePlayerGnew(1, -1, map.Length);
                            break;
                        case ConsoleKey.NumPad3:
                            MovePlayerGnew(1, 1, map.Length);
                            break;
                        case ConsoleKey.Q:
                            Clear(); // clear the screen for the draw of menu
                            return; // Exit the loop
                    }
                }
            }
        }

        // FIX: TODO: THIS CODE IS TERRIBLE DO A REWRITE YOU LAZY PIECE OF SHIT
        public void MovePlayerGnew(int deltaRow, int deltaCol, int mapLength)
        {
            if (loadedScenario != null && loadedScenario.Player != null)
            {
                bool inviztrap = false;
                string deathmessage = "";

                int newRow = loadedScenario.Player.Position.X + deltaRow;
                int newCol = loadedScenario.Player.Position.Y + deltaCol;
                MapTile nextSpace = map[newRow, newCol];

                if (loadedScenario.Traps.Count > 0)
                {
                    for (int i = 0; i < loadedScenario.Traps.Count; i++)
                    {
                        if (newRow == loadedScenario.Traps[i].Position.X && newCol == loadedScenario.Traps[i].Position.Y)
                        {
                            nextSpace = loadedScenario.Traps[i].Symbol;
                            if (loadedScenario.Traps[i].Symbol != MapTile.Trap)
                            {
                                inviztrap = true;
                            }
                        }
                    }
                }

                if (!gameOver)
                {
                    if (nextSpace != MapTile.Wall)
                    {
                        map[newRow, newCol] = MapTile.Player;
                        SetCursorPosition(newCol, newRow + 1);
                        Write((char)MapTile.Player);

                        map[loadedScenario.Player.Position.X, loadedScenario.Player.Position.Y] = yourSpace;
                        SetCursorPosition(loadedScenario.Player.Position.Y, loadedScenario.Player.Position.X + 1);
                        Write("{0}", (char)yourSpace);

                        loadedScenario.Player.Position.X = newRow;
                        loadedScenario.Player.Position.Y = newCol;
                        yourSpace = nextSpace;
                        output = "";
                    }
                    else
                    {
                        output = "wall, you can't continue this way";
                    }

                    if (yourSpace == MapTile.Trap || inviztrap == true)
                    {
                        loadedScenario.Player.Health -= 10;
                        output = "Ouch, you stepped in a trap";
                        deathmessage = "You got impaled on a trap. ";
                    }

                    if (yourSpace == MapTile.Air)
                    {
                        loadedScenario.Player.Health = 0;
                        SetCursorPosition(loadedScenario.Player.Position.Y, loadedScenario.Player.Position.X + 1);
                        Write("{0}", (char)yourSpace);
                        deathmessage = "You fell into the void. ";
                    }

                    if (loadedScenario.Player.Health <= 0)
                    {
                        output = deathmessage + "You're dead!";
                        gameOver = true;
                        return;
                    }
                }
            }
        }

        public static string? LoadStoryFromFile(string filePath = "./Story/G3_lvl1.txt")
        {
            try
            {
                // Use Path.Combine to handle relative paths correctly
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

                // Read all text from the file
                string storyText = File.ReadAllText(fullPath);
                return storyText;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: File not found at {filePath}");
                return null; // Or throw an exception, depending on your error handling
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Error: Directory not found at {filePath}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading story: {ex.Message}");
                return null; // Or throw an exception
            }
        }
    }
}
