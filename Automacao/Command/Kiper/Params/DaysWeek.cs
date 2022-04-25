
using System.Text.Json.Serialization;

namespace Automacao.Command.Kiper.Params
{
    class DaysWeek
    {
        [JsonPropertyName("monday")]
        public List<string>? Monday { get; set; } = new List<string>();
        [JsonPropertyName("tuesday")]
        public List<string>? Tuesday { get; set; } = new List<string>();
        [JsonPropertyName("wednesday")]
        public List<string>? Wednesday { get; set; } = new List<string>();
        [JsonPropertyName("thursday")]
        public List<string>? Thursday { get; set; } = new List<string>();
        [JsonPropertyName("friday")]
        public List<string>? Friday { get; set; } = new List<string>();
        [JsonPropertyName("saturday")]
        public List<string>? Saturday { get; set; } = new List<string>();
        [JsonPropertyName("sunday")]
        public List<string>? Sunday { get; set; } = new List<string>();

        public DaysWeek(List<string>? monday = null, List<string>? tuesday = null, List<string>? wednesday = null,
            List<string>? thursday = null, List<string>? friday = null, List<string>? saturday = null, List<string>? sunday = null) 
        {
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Tuesday = tuesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
            Sunday = sunday;
        }
        
    
    }
}
