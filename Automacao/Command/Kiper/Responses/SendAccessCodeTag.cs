using System.Text.Json.Serialization;
using Automacao.Entity;

namespace Automacao.Command.Kiper.Params;

public class SendAccessCodeTag
{
    [JsonPropertyName("from_device")]
    public Device FromDevice { get; set; }
    
    [JsonPropertyName("from_ipwall_id")]
    public int FromIpwallId { get; set; }
    
    [JsonPropertyName("tag_id")]
    public long TagId { get; set; }
    
    [JsonPropertyName("reader")]
    public int Reader { get; set; }
    
    [JsonPropertyName("access")]
    public Access Access { get; set; }

    public SendAccessCodeTag(Profile profile)
    {
        //FromDevice = new Device(profile.ListDevice);
    }
}

