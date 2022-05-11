using Automacao.Entity.Aws;
using Automacao.Script;
using Automacao.Service.Aws;
using Automacao.Command.Enum;
using Automacao.Entity;

//https://hexquote.com/aws-iot-with-net-core-mqtt/


SettingsAws clientAws = new();
MessagesAws device = new(clientAws, "1058511");

Profile profile = new (UsersEnum.MANOEL);

await AcessoComTagValida.Execute(device, profile);
Console.WriteLine("FIM");


