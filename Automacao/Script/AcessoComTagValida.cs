using Automacao.Service.Aws;
using static Automacao.Command.Kiper.Command;
using static Automacao.Command.Enum.CommandEnum;
using static Automacao.Command.Enum.UsersEnum;
using static Automacao.Entity.Users;
using Automacao.Command.Kiper.Params;

namespace Automacao.Script;

public class AcessoComTagValida
{
    public static void Execute(MessagesAws device, User profile)
    {
        SendCommand(INSERT_USER, profile, device);
    }
}