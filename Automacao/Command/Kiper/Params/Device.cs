using System.Text.Json.Serialization;

namespace Automacao.Command.Kiper.Params;

public class Device
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }

    public Device(int id, string type)
    {
        Id = id;
        Type = type;
    }
}