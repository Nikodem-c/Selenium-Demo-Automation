using Newtonsoft.Json.Linq;

namespace SauceDemoAutomation.Utilities
{
    // Utility class for reading test data from a JSON file
    // Example usage: ExtractData("standard_user")

    internal class JsonReader
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Utilities", "Data.json");

        public string? ExtractData(string token)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("JSON data file not found at path: " + filePath);
            }

            string jsonString = File.ReadAllText(filePath);

            var jsonParsed = JToken.Parse(jsonString);
            var value = jsonParsed.SelectToken(token);

            if (value == null)
            {
                throw new ArgumentException($"Token '{token}' not found in JSON");
            }

            return value.Value<string>();
        }

        public string[] ExtracDataArray(string token)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("JSON data file not found at path: " + filePath);
            }

            string jsonString = File.ReadAllText(filePath);

            var jsonParsed = JToken.Parse(jsonString);
            var value = jsonParsed.SelectToken(token);

            if (value == null || value.Type != JTokenType.Array)
            {
                throw new ArithmeticException($"Token '{token}' not found or is not an array.");
            }
            return value.Select( v => v.ToString()).ToArray();
        }
    }
}
