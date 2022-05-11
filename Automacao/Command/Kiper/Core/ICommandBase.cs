
using System.Text.Json.Serialization;

namespace Automacao.Command.Kiper.Core
{
    interface ICommandBase
    {
        [JsonPropertyName("cmd")] public string Cmd { get; set; }
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("esn")] public string Esn { get; set; }
        [JsonPropertyName("datetime")] public string DateTimeNow { get; set; }
        
    }
}
