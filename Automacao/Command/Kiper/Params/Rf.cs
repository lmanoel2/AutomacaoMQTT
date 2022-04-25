
using System.Text.Json.Serialization;

namespace Automacao.Command.Kiper.Params
{
    class Rf
    {
        [JsonPropertyName("rf_id")]
        public long RfId { get; set; }
        [JsonPropertyName("counter_rf")]
        public int CounterRf { get; set; }

        public Rf(long rfId, int counterRf)
        {
            RfId = rfId;
            CounterRf = counterRf;
        }
    }
}
