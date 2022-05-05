
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
        
        Task<bool> resultAckInsertUser = ResponseDevice(new CancellationTokenSource(TimePassTag).Token, new Ack(idMessageSended),  device);
        
        await resultAckInsertUser;
  
    }
}