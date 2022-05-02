using System.Diagnostics;
using System.Text;
using Automacao.Service.Aws;
using static Automacao.Command.Kiper.Command;
using static Automacao.Command.Enum.CommandEnum;
using Automacao.Entity;
using static Automacao.Entity.Time;
using System.Text.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;


namespace Automacao.Script;

public class AcessoComTagValida
{
    public static async Task Execute(MessagesAws device, Profile profile)
    {
        SendCommand(INSERT_USER, profile, device);
        CancellationToken ctToken = new CancellationTokenSource(TimePassTag).Token;
        while (device.MessageReceived == null)
        {
        }

        JObject json = JObject.Parse(Encoding.UTF8.GetString(device.MessageReceived.Message));
        
        Console.WriteLine(json);
        Console.WriteLine(json["cmd"]);
        //var result = await PassTag(device, ctToken);
       // Console.WriteLine(result);
    }

    static async Task<bool> PassTag(MessagesAws device, CancellationToken ct)
    {
        while (true)
        {
            Console.WriteLine('a');
            Console.WriteLine($"--------------{device.MessageReceived}");
            
            if (device.MessageReceived != null) 
                return true;
            if (ct.IsCancellationRequested) 
                return false;
            
        }
        
    }
}