
using System.Text.Json.Serialization;

namespace Automacao.Command.Kiper.Params
{
    class Ipwall
    {
        [JsonPropertyName("door_id")]
        public int DoorId { get; set; }
        [JsonPropertyName("ipwall_id")]
        public int IpwallId { get; set; }

        public Ipwall(int ipwallId, int doorId)
        {
            DoorId = doorId;
            IpwallId = ipwallId;
        }
    }
}
