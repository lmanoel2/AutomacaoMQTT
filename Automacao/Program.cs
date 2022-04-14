using entidades.aws;
using servicos.aws;

//https://hexquote.com/aws-iot-with-net-core-mqtt/

string broker = "a2q2wk17nbok8r-ats.iot.eu-west-1.amazonaws.com";
int port = 8883;
var clientId = "TesteAutomacao";
string certPass = "kiper";
string serialCPU = "131274";
string topicPublish = $"Kiper/Device/Sended/{serialCPU}";
string topicSubscribe = $"Kiper/Device/Received/{serialCPU}";


ConfiguracaoAWS clientAWS = new(broker, port, clientId, certPass);
ComunicacaoMQTT device = new(clientAWS, topicPublish, topicSubscribe);

ushort result = await device.Subscribe();

device.Publish("Testando");
Console.ReadKey();


