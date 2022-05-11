using System.Diagnostics;
using Automacao.Command.Kiper.Requests;
using System.Text.Json;
using Automacao.Command.Enum;
using Automacao.Command.Kiper.Core;
using Automacao.Entity;
using Automacao.Service.Aws;
using Newtonsoft.Json.Linq;

namespace Automacao.Command.Kiper
{
    internal static class Command
    {
        public static long SendCommand(CommandEnum command, Profile profile, MessagesAws device)
        {
            device.IdMessages++;
            
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = false
            };

            switch (command)
            {
                case CommandEnum.INSERT_USER:
                    var jsonString = JsonSerializer.Serialize(new InsertUserRequest(profile.User), serializeOptions);
                    Console.WriteLine("[ENVIADO] " + jsonString);
                    device.Publish(jsonString);
                    break;
            };
            return device.IdMessages;
        }
        
        public static async Task<bool> ResponseDevice(CancellationToken ctToken, ICommandBase messageExpected, MessagesAws device)
        {
            bool checkMessage = false;
            await Task.Run(() =>
            {
                while (!ctToken.IsCancellationRequested && !checkMessage)
                {
                    if (device.GetMessageReceived() != null)
                    {
                        messageExpected.DateTimeNow = device.GetMessageReceived()?["datetime"].ToString();
                        var jsonString = JsonSerializer.Serialize(messageExpected, new JsonSerializerOptions {WriteIndented = false});
                        
                        checkMessage = JToken.DeepEquals(JObject.Parse(jsonString), device.GetMessageReceived());
                        return;
                    }
                }
            });
            return checkMessage;
        }
        
        
    }
}
