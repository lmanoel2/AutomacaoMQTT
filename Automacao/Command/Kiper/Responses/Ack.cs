using System.Text.Json.Serialization;
using Automacao.Command.Kiper.Core;

namespace Automacao.Command.Kiper.Responses;

public class Ack : ICommandBase
{
    
    [JsonPropertyName("cmd")]
    public string Cmd { get; set; }
    [JsonPropertyName("datetime")]
    public string DateTimeNow { get; set; }
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    public Ack(long id)
    {
        Cmd = "ack";
        DateTimeNow = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        Id = id;
    }
    
}