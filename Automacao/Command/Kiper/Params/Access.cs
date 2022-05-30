using System.Text.Json.Serialization;

namespace Automacao.Command.Kiper.Params;

public class Access
{
    [JsonPropertyName("allowed")]
    public bool Allowed { get; set; }
    
    [JsonPropertyName("reason")]
    public int Reason { get; set; }

    public Access(int reason, bool allowed)
    {
        Reason = reason;
        Allowed = allowed;
    }
}