using System.Text;
using Automacao.Entity.Aws;
using Newtonsoft.Json.Linq;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Automacao.Service.Aws
{
    public class MessagesAws
    {
        private SettingsAws DeviceAWS;
        private string TopicPublish { get; }
        private string TopicSubscribe { get; }
        public bool IsSubscribe { get; set; }
        public long IdMessages { get; set; }
        public JObject MessageReceived { get; set; }

        public MessagesAws(SettingsAws clientAws, string serialCpu)
        {
            DeviceAWS = clientAws;
            TopicPublish = $"Kiper/Device/Sended/{serialCpu}";
            TopicSubscribe = $"Kiper/Device/Received/{serialCpu}";
            IsSubscribe = false;
            IdMessages = 0;


            DeviceAWS.Client.MqttMsgSubscribed += IotClient_MqttMsgSubscribed;
            DeviceAWS.Client.MqttMsgPublishReceived += IotClient_MqttMsgPublishReceived;
            Subscribe();
        }

        public void Publish(string mensagem)
        {
            DeviceAWS.Client.Publish(TopicPublish, Encoding.UTF8.GetBytes(mensagem));
        }

        public void Subscribe()
        {
            var result = DeviceAWS.Client.Subscribe(new string[] {TopicSubscribe},
                new byte[] {MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE});

            if (result != 1)
            {
                Console.Write("[ERROR] Não foi possível subscrever no tópico. Saindo...");
                Environment.Exit(0);
            }

            while (!IsSubscribe)
            {
            }
        }

        private void IotClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.Write("[RECEBIDO] " + Encoding.UTF8.GetString(e.Message));
            MessageReceived = JObject.Parse(Encoding.UTF8.GetString(e.Message));
        }

        private void IotClient_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Console.WriteLine($"[INFO] Subscrito com sucesso!");
            IsSubscribe = true;
        }

        public JObject? GetMessageReceived()
        {
            return MessageReceived;
        }

        public void Finish()
        {
            DeviceAWS.Client.Disconnect();
        }
        
        
    }
}