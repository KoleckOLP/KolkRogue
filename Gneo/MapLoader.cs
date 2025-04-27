
using System.Reflection;
using static System.Console;

namespace Gneo
{
    internal class MapLoader
    {
        public static string? LoadMapFromFile(string filePath = "./Story/level1_map.txt")
        {
            string processedPath;

            try
            {
                // attempting to fix file not being found when not ran from build dir
                if (filePath.StartsWith('.'))
                {
                    processedPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath.Substring(2));
                }
                else 
                {
                    // Use Path.Combine to handle relative paths correctly
                    processedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
                }

                // Read all text from the file
                string storyText = File.ReadAllText(processedPath);
                return storyText;
            }
            catch (FileNotFoundException)
            {
                WriteLine($"Error: File not found at {filePath}");
                return null; // Or throw an exception, depending on your error handling
            }
            catch (DirectoryNotFoundException)
            {
                WriteLine($"Error: Directory not found at {filePath}");
                return null;
            }
            catch (Exception ex)
            {
                WriteLine($"Error loading story: {ex.Message}");
                return null; // Or throw an exception
            }
        }
    }
}
