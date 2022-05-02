using Automacao.Service.Aws;
using static Automacao.Command.Kiper.Command;
using static Automacao.Command.Enum.CommandEnum;
using Automacao.Entity;
using System.Text.Json;


namespace Automacao.Script;

public class AcessoComTagValida
{
    public static void Execute(MessagesAws device, Profile profile)
    {
        SendCommand(INSERT_USER, profile, device);

        while (device.MessageReceived == null)
        {
        }

        Console.WriteLine($"--{device.MessageReceived}");
        var serializeOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        
        var jsonString = JsonSerializer.Serialize(device.MessageReceived, serializeOptions);
        Console.WriteLine(jsonString);
    }

    public void PassTag()
    {
    }
}