using Automacao.Actions;
using Automacao.Entity.Aws;
//using Automacao.Script;
using Automacao.Service.Aws;
using Automacao.Command.Enum;
using Automacao.Entity;

//https://hexquote.com/aws-iot-with-net-core-mqtt/


SettingsAws clientAws = new();
MessagesAws device = new(clientAws, "105851");

Profile profile = new (UsersEnum.MANOEL);

bool resultInsertUser = await InsertUserAction.Execute(profile, device);
Console.WriteLine(resultInsertUser);
Console.WriteLine("FIM");


