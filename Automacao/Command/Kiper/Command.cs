using Automacao.Command.Kiper.Requests;
using System.Text.Json;
using Automacao.Command.Enum;
using Automacao.Command.Kiper.Params;
using Automacao.Service.Aws;

namespace Automacao.Command.Kiper
{
    class Command
    {
        public static void SendCommand(CommandEnum command, User user, MessagesAws device)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            switch (command)
            {
                case CommandEnum.INSERT_USER:
                    var jsonString = JsonSerializer.Serialize(new InsertUserRequest(user), serializeOptions);
                    Console.WriteLine(jsonString);
                    device.Publish(jsonString);
                    break;
            };
        }
    }
}
