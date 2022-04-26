
using System.Text.Json.Serialization;

namespace Automacao.Command.Kiper.Params
{
    public class Ipwall
    {
        [JsonPropertyName("door_id")]
        public int DoorId { get; set; }
        [JsonPropertyName("ipwall_id")]
        public int IpwallId { get; set; }

        public string Ip { get; set; }
        public string Name { get; set; }
        public Ipwall(int ipwallId, int doorId, string ip, string name)
        {
            DoorId = doorId;
            IpwallId = ipwallId;
            Ip = ip;
            Name = name;
        }
    }
}
