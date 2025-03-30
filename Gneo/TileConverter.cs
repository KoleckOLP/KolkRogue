namespace Gneo;

    public class TileConverter
    {
        public static MapTile[,] ConvertStringToMapTileArray(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new MapTile[0, 0]; // Return empty array for null or empty input
            }

            string[] lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = lines.Length;
            int cols = lines[0].Length; // FIX: TODO: This line assumes that all lines are the same length

            MapTile[,] tileArray = new MapTile[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char currentChar = lines[row][col];

                    switch (currentChar)
                    {
                        case (char)MapTile.Wall:
                            tileArray[row, col] = MapTile.Wall;
                            break;
                        case (char)MapTile.Floor:
                            tileArray[row, col] = MapTile.Floor;
                            break;
                        case (char)MapTile.Player:
                            tileArray[row, col] = MapTile.Player;
                            break;
                        case (char)MapTile.Trap:
                            tileArray[row, col] = MapTile.Trap;
                            break;
                        default:
                            tileArray[row, col] = MapTile.Air;
                            break;
                    }
                }
            }

            return tileArray;
        }

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