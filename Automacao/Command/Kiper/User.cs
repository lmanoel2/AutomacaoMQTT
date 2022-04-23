
using System.Text.Json.Serialization;


namespace Automacao.Command.Kiper
{
   
    class User
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        [JsonPropertyName("user_type")]
        public int UserType { get; set; }
        [JsonPropertyName("set_rf_id")]
        public int SetRfId { get; set; }
        [JsonPropertyName("secret")]
        public string Secret { get; set; }
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
        public string ValidFrom { get; set; }
        [JsonPropertyName("valid_until")]
        public string ValidUntil { get; set; }
        [JsonPropertyName("access_counter")]
        public int AccessCounter { get; set; }
        [JsonPropertyName("restrict_acess")]
        public bool RestrictAccess { get; set; }
        [JsonPropertyName("days_of_week")]
        public int DaysWeek { get; set; }
        public User(int userId, int userType, int setRfId, string secret, int openingTime, 
                    bool administrator, string validFrom, string validUntil, int accessCounter, bool restrictAccess)
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

            Tags = null;
            Rfs = null;
            IpwallAccess = null;
        }


        public void AddTag(long tag)
        {
            if (Tags == null) Tags = new List<long>();
            Tags.Add(tag);
        }
    }
}
