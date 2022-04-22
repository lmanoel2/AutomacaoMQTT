using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Automacao.comandos.kiper
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
        public List<Ipwall>? IpwallAccess { get; set; } = new List<Ipwall>();
        public List<Rf>? Rfs { get; set; } = new List<Rf>();
        public string ValidFrom { get; set; }
        public string ValidUntil { get; set; }
        public int AccessCounter { get; set; }
        
        //DataContractJsonSerializer(typeof (List<string>))
        public User(int userId, int userType, int setRfId, string secret, int openingTime, bool administrator, string validFrom, string validUntil, int accessCounter)
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

            IpwallAccess = null;
            Rfs = null;
            //Tags = null;
        }


        public void AddTag(long tag)
        {
            Tags.Add(tag);
        }
    }
}
