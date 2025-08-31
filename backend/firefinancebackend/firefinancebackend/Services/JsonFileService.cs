using System.Text.Json;

namespace firefinancebackend.Services
{
    public class JsonFileService
    {
        public List<T> ReadData<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<T>();
        }

        public void AppendData<T>(string filePath, T newItem)
        {
            var data = ReadData<T>(filePath);
            data.Add(newItem);
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
