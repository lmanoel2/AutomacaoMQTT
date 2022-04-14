using System.Security.Cryptography.X509Certificates;
using uPLibrary.Networking.M2Mqtt;

namespace entidades.aws
{
    class ConfiguracaoAWS
    {
        private string Broker { get;  set; }
        private int Port { get;  set; }
        private string ClientId { get;  set; }
        private string CertPass { get;  set; }
        private string CertificatesPath { get;  set; }
        private string CaCertPath { get;  set; }
        private string DeviceCertPath { get;  set; }
        private X509Certificate CaCert { get;  set; }
        private X509Certificate DeviceCert { get;  set; }
        public MqttClient Client { get;  private set; }

        public ConfiguracaoAWS(string broker, int port, string clientId, string certPass)
        {
            Broker = broker;
            Port = port;
            ClientId = clientId;
            CertPass = certPass;

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
            Console.WriteLine($"Connected to AWS IoT with client id: {clientId}");
        }

    }
}
