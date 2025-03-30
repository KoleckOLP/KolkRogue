using System.Text.Json.Serialization;
using System.Text.Json;
using static System.Console;

namespace Gneo
{
    public static class ScenearioSearilizer
    {
        public static void SaveScenario(Scenario scenario, string filePath = "scenario.json")
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

        public static Scenario? LoadScenario(string filePath = "scenario.json")  // I allowed it to be nulleble
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            try
            {
                string jsonString = File.ReadAllText(filePath);
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
