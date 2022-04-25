using Automacao.Service.Aws;
using static Automacao.Command.Kiper.Command;
using static Automacao.Command.Enum.CommandEnum;
using static Automacao.Command.Enum.UsersEnum;
using static Automacao.Entity.Users;

namespace Automacao.Script;

public class AcessoComTagValida
{
    public static void Execute(MessagesAws device)
    {
        SendCommand(INSERT_USER, UserManoel(), device);
    }
}