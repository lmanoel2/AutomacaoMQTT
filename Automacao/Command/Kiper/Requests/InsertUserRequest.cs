﻿
using System.Text.Json.Serialization;
using Automacao.Command.Kiper.Core;
using Automacao.Command.Kiper.Params;

namespace Automacao.Command.Kiper.Requests
{
    class InsertUserRequest : ICommandBase
    {
        [JsonPropertyName("cmd")]
        public string Cmd { get; set; }
        [JsonPropertyName("datetime")]
        public string DateTimeNow { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("params")]
        public object User { get; set; }
        
        [JsonPropertyName("esn")] 
        public string Esn { get; set; }
        

        public InsertUserRequest(User user, long id)
        {
            User = user;
            DateTimeNow = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            Id = id;
            Cmd = "insert_user";
            Esn = "1058511";
        }
    }
}