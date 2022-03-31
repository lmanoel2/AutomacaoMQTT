
using System.Security.Cryptography.X509Certificates;
using System.Text;
using uPLibrary.Networking.M2Mqtt;

string broker = "a2q2wk17nbok8r-ats.iot.eu-west-1.amazonaws.com";
int port = 8883;
var clientId = "TesteAutomacao";
string certPass = "kiper";

var certificatesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "certs");

var caCertPath = Path.Combine(certificatesPath, "AmazonRootCA1.pem");
var caCert = X509Certificate.CreateFromCertFile(caCertPath);

var deviceCertPath = Path.Combine(certificatesPath, "certificate.cert.pfx");
var deviceCert = new X509Certificate(deviceCertPath, certPass);

var client = new MqttClient(broker, port, true, caCert, deviceCert, MqttSslProtocols.TLSv1_2);

client.Connect(clientId);
Console.WriteLine($"Connected to AWS IoT with client id: {clientId}");

var message = "Hello from .NET Core";
int i = 1;

while(i<=10)
{
    client.Publish("Kiper/Device/Sended/131274", Encoding.UTF8.GetBytes($"{message} {i}"));
    Console.WriteLine($"Published: {message} {i}");
    i++;
    Thread.Sleep(2000);
}
