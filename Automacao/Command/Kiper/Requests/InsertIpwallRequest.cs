using System.Text.Json.Serialization;
using Automacao.Command.Kiper.Core;
using Automacao.Command.Kiper.Params;

namespace Automacao.Command.Kiper.Requests;

public class InsertIpwallRequest : ICommandBase
{
    [JsonPropertyName("cmd")] 
    public string Cmd { get; set; }
    
    [JsonPropertyName("datetime")] 
    public string DateTimeNow { get; set; }
    
    [JsonPropertyName("id")] 
    public long Id { get; set; }

    [JsonPropertyName("esn")] 
    public string Esn { get; set; }
    
    [JsonPropertyName("params")] 
    public Ipwall Ipwall { get; set; }
    
}