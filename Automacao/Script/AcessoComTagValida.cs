using Automacao.Service.Aws;
using static Automacao.Command.Kiper.Command;
using static Automacao.Command.Enum.CommandEnum;
using Automacao.Entity;
using static Automacao.Entity.Time;
using Automacao.Command.Kiper.Responses;


namespace Automacao.Script;

public static class AcessoComTagValida
{
    public static async Task Execute(MessagesAws device, Profile profile)
    {
        long idMessageSended = SendCommand(INSERT_USER, profile, device);
        
        Task<bool> resultAckInsertUser = ResponseDevice(new CancellationTokenSource(TimeAck).Token, new Ack(25),  device);
        
        //if (!await resultAckInsertUser) return;
        
        var x = await resultAckInsertUser;
        Console.WriteLine(x);
        Console.WriteLine("Passe a Tag");
  
    }
}