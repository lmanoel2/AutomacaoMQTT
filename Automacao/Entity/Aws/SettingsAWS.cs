using System.Security.Cryptography.X509Certificates;
using uPLibrary.Networking.M2Mqtt;

namespace Automacao.Entity.Aws
{
    class SettingsAWS
    {
        private string Broker = "a2q2wk17nbok8r-ats.iot.eu-west-1.amazonaws.com";
        private int Port = 8883;
        private string ClientId = "TesteAutomacao";
        private string CertPass = "kiper";
        private string CertificatesPath { get;  set; }
        private string CaCertPath { get;  set; }
        private string DeviceCertPath { get;  set; }
        private X509Certificate CaCert { get;  set; }
        private X509Certificate DeviceCert { get;  set; }
        public MqttClient Client { get;  private set; }

        public SettingsAWS()
        {
            try
            {
                CertificatesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "certs");
                CaCertPath = Path.Combine(CertificatesPath, "AmazonRootCA1.pem");
                CaCert = X509Certificate.CreateFromCertFile(CaCertPath);
                DeviceCertPath = Path.Combine(CertificatesPath, "certificate.cert.pfx");
                DeviceCert = new X509Certificate(DeviceCertPath, CertPass);
                Client = new MqttClient(Broker, Port, true, CaCert, DeviceCert, MqttSslProtocols.TLSv1_2);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Environment.Exit(0);
            }

            Client.Connect(ClientId);
            Console.WriteLine($"Connected to AWS IoT with client id: {ClientId}");
        }

    }
}
