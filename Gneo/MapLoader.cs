
namespace Gneo
{
    internal class MapLoader
    {
        public static string? LoadMapFromFile(string filePath = "./Story/level1_map.txt")
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
