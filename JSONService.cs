using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JSONService
{
    private string _filePath;

    public JSONService(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(List<Appointment> appointments)
    {
        string json = JsonSerializer.Serialize(appointments, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public List<Appointment> Load()
    {
        if (!File.Exists(_filePath)) return new List<Appointment>();
        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Appointment>>(json);
    }
}
