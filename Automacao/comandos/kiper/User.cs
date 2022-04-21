using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Automacao.comandos.kiper
{
    class User
    {
        public int UserId { get; set; }
        public int UserType { get; set; }
        public int SetRfId { get; set; }
        public string Secret { get; set; }
        public int OpeningTime { get; set; }
        public bool Administrator { get; set; }
        public List<long>? Tags { get; set; }
        public List<Ipwall>? IpwallAccess { get; set; }
        public List<Rf>? Rfs { get; set; }
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
            Tags = new List<long>{ 1,2};
        }


        public void AddTag(long tag)
        {
            Tags.Add(tag);
            Tags.ToArray();
        }
    }
}
