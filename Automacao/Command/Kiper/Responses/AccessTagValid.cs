using System.Text.Json.Serialization;
using Automacao.Command.Kiper.Core;

namespace Automacao.Command.Kiper.Responses;

public class AccessTagValid : ICommandBase
{
    [JsonPropertyName("cmd")]
    public string Cmd { get; set; }
    [JsonPropertyName("datetime")]
    public string DateTimeNow { get; set; }
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("esn")] 
    public string Esn { get; set; }
    [JsonPropertyName("gw_type")] 
    public string gwType { get; set; }
    
    public AccessTagValid(long id)
    {
        Cmd = "send_access_code_tag";
        DateTimeNow = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        Id = id;
        Esn = "105851";
        gwType = "K4";
    }
}