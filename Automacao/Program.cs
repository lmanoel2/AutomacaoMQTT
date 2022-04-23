using Entity.Aws;
using Service.Aws;
using Automacao.Command.Kiper;

//https://hexquote.com/aws-iot-with-net-core-mqtt/

string broker = "a2q2wk17nbok8r-ats.iot.eu-west-1.amazonaws.com";
int port = 8883;
var clientId = "TesteAutomacao";
string certPass = "kiper";
string serialCPU = "134288";
string topicPublish = $"Kiper/Device/Sended/{serialCPU}";
string topicSubscribe = $"Kiper/Device/Received/{serialCPU}";


SettingsAWS clientAWS = new(broker, port, clientId, certPass);
MessagesAWS device = new(clientAWS, topicPublish, topicSubscribe);

device.Subscribe();

User userManoel = new User( userId: 2941, 
                            userType: 0, 
                            setRfId: 2,
                            secret: "123DWAD4AW", 
                            openingTime: 8, 
                            administrator: true,
                            validFrom: DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                            validUntil: DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), 
                            accessCounter: 2,
                            restrictAccess: false);
//userManoel.AddTag(123);
//userManoel.AddTag(3333);
Command.InsertUser(userManoel);



//device.Publish(insertUser);
//Console.WriteLine(insertUser);
Console.ReadKey();


