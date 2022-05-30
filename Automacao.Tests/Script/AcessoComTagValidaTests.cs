using Automacao.Actions;
using Automacao.Command.Enum;
using Automacao.Command.Kiper.Responses;
using Automacao.Entity;
using Automacao.Entity.Aws;
using Automacao.Service.Aws;
using Automacao.Command.Kiper.Responses;
using Xunit;

namespace Automacao.Tests.Script;

public class AcessoComTagValidaTests
{
    private SettingsAws _clientAws;
    private MessagesAws _device;
    private Profile _profile;

    public AcessoComTagValidaTests()
    {
        _clientAws = new();
        _device = new(_clientAws, "105851");
        _profile = new(UsersEnum.MANOEL);
    }

    [Fact]
    public async void InserirUsuarioValido()
    {
        bool resultInsertUser = await InsertUserAction.Execute(_profile, _device);

        Assert.True(resultInsertUser);
        _device.Finish();
    }

    [Fact]
    public async void PassarTagValida()
    {
        bool resultInsertUser = await InsertUserAction.Execute(_profile, _device);
        bool resultAccessTag = await PassTagAction.Execute(_profile, _device);

        Assert.True(resultInsertUser);
        Assert.True(resultAccessTag);
        _device.Finish();
    }
}