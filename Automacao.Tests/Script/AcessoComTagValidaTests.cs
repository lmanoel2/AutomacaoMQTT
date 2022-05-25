using Automacao.Actions;
using Automacao.Command.Enum;
using Automacao.Entity;
using Automacao.Entity.Aws;
using Automacao.Service.Aws;
using Xunit;

namespace Automacao.Tests.Script;

public class AcessoComTagValidaTests
{
    [Fact]
    public async void InserirUsuario()
    {
        SettingsAws clientAws = new();
        MessagesAws device = new(clientAws, "105851");
        Profile profile = new (UsersEnum.MANOEL);
        
        bool resultInsertUser = await InsertUser.Execute(profile, device);
        
        Assert.True(resultInsertUser);
        device.Finish();
    }
    [Fact]
    public void PassarTag()
    {
        Assert.True(true);
    }
}