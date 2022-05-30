using Automacao.Service.Aws;
using static Automacao.Command.Kiper.Core.Command;
using static Automacao.Command.Enum.CommandEnum;
using Automacao.Entity;
using static Automacao.Entity.Time;
using Automacao.Command.Kiper.Responses;

namespace Automacao.Actions;

public class InsertUserAction
{
    public static async Task<bool> Execute(Profile profile, MessagesAws device)
    {
        Task<bool> resultAckInsertUser = ResponseDevice(new CancellationTokenSource(TimeAck).Token, new Ack(SendCommand(INSERT_USER, profile, device)),  device);

        return await resultAckInsertUser;
    }
}