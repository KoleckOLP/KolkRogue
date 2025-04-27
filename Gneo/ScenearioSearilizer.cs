using System.Text.Json.Serialization;
using System.Text.Json;
using static System.Console;
using System.Reflection;

namespace Gneo
{
    public static class ScenearioSearilizer
    {
        public static void SaveScenario(Scenario scenario, string filePath = "./Story/level1_sceneario.json")
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                WriteIndented = true
            };

            try
            {
                string jsonString = JsonSerializer.Serialize(scenario, options);
                File.WriteAllText(filePath, jsonString);
                WriteLine($"Scenario saved to {filePath}");
            }
            catch (Exception ex)
            {
                WriteLine($"Error saving scenario: {ex.Message}");
            }
        }

        public static Scenario? LoadScenario(string filePath = "./Story/level1_sceneario.json")  // I allowed it to be nulleble
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            try
            {
                string processedPath;

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

                string jsonString = File.ReadAllText(processedPath);
                return JsonSerializer.Deserialize<Scenario>(jsonString, options);
            }
            catch (Exception ex)
            {
                WriteLine($"Error loading scenario: {ex.Message}");
                return null;
            }
        }
    }
}
