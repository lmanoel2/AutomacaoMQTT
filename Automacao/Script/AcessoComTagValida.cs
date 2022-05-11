using Automacao.Service.Aws;
using static Automacao.Command.Kiper.Command;
using static Automacao.Command.Enum.CommandEnum;
using Automacao.Entity;
using static Automacao.Entity.Time;
using Automacao.Command.Kiper.Responses;
using Automacao.Actions;


namespace Automacao.Script;

public static class AcessoComTagValida
{
    public static async Task<bool> Execute(MessagesAws device, Profile profile)
    {
        var resultInsertUser = await InsertUser.Execute(profile, device);

        if (!resultInsertUser) return false;

        return true;
    }
}