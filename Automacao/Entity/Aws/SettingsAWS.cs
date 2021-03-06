using System.Security.Cryptography.X509Certificates;
using uPLibrary.Networking.M2Mqtt;

namespace Automacao.Entity.Aws
{
    public class SettingsAws
    {
        private readonly string _broker = "a2q2wk17nbok8r-ats.iot.eu-west-1.amazonaws.com";
        private readonly int _port = 8883;
        private readonly string _clientId = "TesteAutomacao";
        private readonly string _certPass = "kiper";
        private string CertificatesPath { get;  set; }
        private string CaCertPath { get;  set; }
        private string DeviceCertPath { get;  set; }
        private X509Certificate CaCert { get;  set; }
        private X509Certificate DeviceCert { get;  set; }
        public MqttClient Client { get;  private set; }

        public SettingsAws()
        {
            try
            {
                CertificatesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "certs");
                CaCertPath = Path.Combine(CertificatesPath, "AmazonRootCA1.pem");
                CaCert = X509Certificate.CreateFromCertFile(CaCertPath);
                DeviceCertPath = Path.Combine(CertificatesPath, "certificate.cert.pfx");
                DeviceCert = new X509Certificate(DeviceCertPath, _certPass);
                Client = new MqttClient(_broker, _port, true, CaCert, DeviceCert, MqttSslProtocols.TLSv1_2);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro --> {ex.Message}      {ex.Source}");
                Environment.Exit(0);
            }

            Client.Connect(_clientId);
            Console.WriteLine($"Connected to AWS IoT with client id: {_clientId}");
        }

    }
}
