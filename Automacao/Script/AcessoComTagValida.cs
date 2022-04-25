using Automacao.Command.Kiper.Params;
using static Automacao.Command.Kiper.Command;
using static Automacao.Command.Enum.CommandEnum;
using static Automacao.Entity.Users;

namespace Automacao.Script;

public class AcessoComTagValida
{
    public static void Execute()
    {
        UserManoel();
        SendCommand(INSERT_USER, UserManoel(), device);
    }
}