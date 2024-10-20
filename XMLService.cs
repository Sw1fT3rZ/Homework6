using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class XMLService
{
    private string _filePath;

    public XMLService(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(List<Appointment> appointments)
    {
        var serializer = new XmlSerializer(typeof(List<Appointment>));
        using (var stream = new FileStream(_filePath, FileMode.Create))
        {
            serializer.Serialize(stream, appointments);
        }
    }

    public List<Appointment> Load()
    {
        if (!File.Exists(_filePath)) return new List<Appointment>();
        var serializer = new XmlSerializer(typeof(List<Appointment>));
        using (var stream = new FileStream(_filePath, FileMode.Open))
        {
            return (List<Appointment>)serializer.Deserialize(stream);
        }
    }
}
