namespace Gneo;

    public class TileConverter
    {
        public static MapTile[][] ConvertStringToMapTileArray(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new MapTile[0][]; // Return empty array for null or empty input
            }

            // Split input into lines, removing empty lines
            string[] lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Create a jagged array where the outer array will hold rows
            MapTile[][] tileArray = new MapTile[lines.Length][];

            for (int row = 0; row < lines.Length; row++) // Iterate over each line
            {
                // Dynamically set the length of each row based on the current line
                tileArray[row] = new MapTile[lines[row].Length];

                for (int col = 0; col < lines[row].Length; col++) // Iterate over each character in the line
                {
                    char currentChar = lines[row][col];

                    switch (currentChar)
                    {
                        case '#':
                            tileArray[row][col] = MapTile.Wall;
                            break;
                        case '.':
                            tileArray[row][col] = MapTile.Floor;
                            break;
                        case '@':
                            tileArray[row][col] = MapTile.Player;
                            break;
                        case 'T':
                            tileArray[row][col] = MapTile.Trap;
                            break;
                        default:
                            tileArray[row][col] = MapTile.Air;
                            break;
                    }
                }
            }

            return tileArray;
        }

    /*public static MapTile[,] ConvertStringToMapTileArray(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return new MapTile[0, 0]; // Return empty array for null or empty input
        }

        string[] lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int rows = lines.Length;
        int cols = lines[0].Length; // FIX: TODO: This line assumes that all lines are the same length

        MapTile[,] tileArray = new MapTile[cols, rows];  // Note that rows and cols are swapped here

        for (int row = 0; row < rows; row++) // 'row' now corresponds to Y (vertical)
        {
            for (int col = 0; col < cols; col++) // 'col' now corresponds to X (horizontal)
            {
                char currentChar = lines[row][col];

                switch (currentChar)
                {
                    case (char)MapTile.Wall:
                        tileArray[col, row] = MapTile.Wall;  // Swapped the indices here
                        break;
                    case (char)MapTile.Floor:
                        tileArray[col, row] = MapTile.Floor; // Swapped the indices here
                        break;
                    case (char)MapTile.Player:
                        tileArray[col, row] = MapTile.Player; // Swapped the indices here
                        break;
                    case (char)MapTile.Trap:
                        tileArray[col, row] = MapTile.Trap; // Swapped the indices here
                        break;
                    default:
                        tileArray[col, row] = MapTile.Air; // Swapped the indices here
                        break;
                }
            }
        }

        return tileArray;
    }*/


    public static void PrintMapTileArray(MapTile[,] tileArray)
        {
            if (tileArray == null || tileArray.GetLength(0) == 0)
            {
                Console.WriteLine("Tile array is empty.");
                return;
            }

            for (int row = 0; row < tileArray.GetLength(0); row++)
            {
                for (int col = 0; col < tileArray.GetLength(1); col++)
                {
                    Console.Write((char)tileArray[row, col]); // Cast MapTile to char for printing
                }
                Console.WriteLine();
            }
        }
    }