
using System.Text.Json.Serialization;


namespace Automacao.Command.Kiper.Params
{
    public class User
    {
        [JsonPropertyName("user_id")]
        public int? UserId { get; set; }
        [JsonPropertyName("user_type")]
        public int UserType { get; set; }
        [JsonPropertyName("set_rf_id")]
        public int? SetRfId { get; set; }
        [JsonPropertyName("secret")]
        public string? Secret { get; set; }
        [JsonPropertyName("opening_time")]
        public int OpeningTime { get; set; }
        [JsonPropertyName("administrator")]
        public bool Administrator { get; set; }
        [JsonPropertyName("tag_id")]
        public List<long>? Tags { get; set; } = new List<long>();
        [JsonPropertyName("ipwall_access_tag")]
        public List<Ipwall>? IpwallAccess { get; set; } = new List<Ipwall>();
        [JsonPropertyName("rf")]
        public List<Rf>? Rfs { get; set; } = new List<Rf>();
        [JsonPropertyName("valid_from")]
        public string? ValidFrom { get; set; }
        [JsonPropertyName("valid_until")]
        public string? ValidUntil { get; set; }
        [JsonPropertyName("access_counter")]
        public int? AccessCounter { get; set; }
        [JsonPropertyName("restrict_acess")]
        public bool RestrictAccess { get; set; }
        [JsonPropertyName("days_of_week")]
        public DaysWeek? DaysWeek { get; set; }
        public User(int? userId = null, int userType = 0, int? setRfId = null, string? secret = null, int openingTime = 3, 
                    bool administrator = false, string? validFrom = null, string? validUntil = null, int? accessCounter = null, 
                    bool restrictAccess = false, DaysWeek? daysWeek = null, List<Ipwall>? ipwallAccess = null, List<long>? tags = null,
                    List<Rf>? rfs = null)
        {
            UserId = userId;
            UserType = userType;
            SetRfId = setRfId;
            Secret = secret;
            OpeningTime = openingTime;
            Administrator = administrator;
            ValidFrom = validFrom;
            ValidUntil = validUntil;
            AccessCounter = accessCounter;
            RestrictAccess = restrictAccess;
            DaysWeek = daysWeek;
            IpwallAccess = ipwallAccess;
            Tags = tags;
            Rfs = rfs;
        }
        public void AddTag(long tag)
        {
            Tags ??= new List<long>();
            Tags.Add(tag);
        }
    }
}

public class IpwallParams
{
    [JsonPropertyName("door_id")]
    public int DoorId { get; set; }
    [JsonPropertyName("ipwall_id")]
    public int IpwallId { get; set; }

    public string Ip { get; set; }
    public string Name { get; set; }
    public IpwallParams(int ipwallId, int doorId, string ip, string name)
    {
        DoorId = doorId;
        IpwallId = ipwallId;
        Ip = ip;
        Name = name;
    }
}
