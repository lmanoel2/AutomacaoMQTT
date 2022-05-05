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
                WriteIndented = true
            };

            switch (command)
            {
                case CommandEnum.INSERT_USER:
                    var jsonString = JsonSerializer.Serialize(new InsertUserRequest(profile.User), serializeOptions);
                    Console.WriteLine(jsonString);
                    device.Publish(jsonString);
                    break;
            };
            return device.IdMessages;
        }
        
        public static async Task<bool> ResponseDevice(CancellationToken ctToken, ICommandBase messageExpected, MessagesAws device)
        {
            bool checkMessage = false;
            JObject? messageExpectedJson = messageExpected as JObject;

            if (messageExpectedJson is null)
            {
                Console.WriteLine($"[Error] Não foi possível converter {messageExpected.ToString()} em JObject");
                return false;
            }
            
            await Task.Run(() =>
            {
                while (!ctToken.IsCancellationRequested || !checkMessage)
                {
                    checkMessage = (messageExpectedJson == device.MessageReceived);
                }
            });
            return checkMessage;
        }
        
        
    }
}
