using entidades.aws;
using servicos.aws;
using comandos.kiper;
using Newtonsoft.Json.Linq;
using Automacao.comandos.kiper;
//https://hexquote.com/aws-iot-with-net-core-mqtt/

string broker = "a2q2wk17nbok8r-ats.iot.eu-west-1.amazonaws.com";
int port = 8883;
var clientId = "TesteAutomacao";
string certPass = "kiper";
string serialCPU = "134288";
string topicPublish = $"Kiper/Device/Sended/{serialCPU}";
string topicSubscribe = $"Kiper/Device/Received/{serialCPU}";


ConfiguracaoAWS clientAWS = new(broker, port, clientId, certPass);
ComunicacaoMQTT device = new(clientAWS, topicPublish, topicSubscribe);

device.Subscribe();

User userManoel = new User(2941, 0, 2, "123DWAD4AW", 8, true, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), 2);
userManoel.AddTag(123);
//userManoel.AddTag(3333);
Comandos.InsertUser(userManoel);

//JObject ipwall1 = new JObject(
//    new JProperty("ipwall_id", 2222),
//    new JProperty("door_id", 1));
//JObject ipwall2 = new JObject(
//    new JProperty("ipwall_id", 3333),
//    new JProperty("door_id", 1));

//JArray listaIpwall = new JArray();


//JObject rf1 = new JObject(
//    new JProperty("rf_id", 2222),
//    new JProperty("counter_rf", 1));
//JObject rf2 = new JObject(
//    new JProperty("rf_id", 123453),
//    new JProperty("counter_rf", 1));

//JArray listaRfID= new JArray();
//listaRfID.Add(rf1);
//listaRfID.Add(rf2);

//Comandos comando = new Comandos();
//List<long> list = new List<long>() {123, 12};
//string validFrom = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
//string validUntil = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

//string insertUser = comando.Insert_user(list, 9999, 2, validFrom, validUntil, 2, listaIpwall, 2941, 2, listaRfID, 2);



//device.Publish(insertUser);
//Console.WriteLine(insertUser);
Console.ReadKey();


