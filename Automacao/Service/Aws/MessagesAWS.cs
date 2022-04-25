using System.Text;
using Automacao.Entity.Aws;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Automacao.Service.Aws
{
    public class MessagesAws
    {
        private SettingsAws DeviceAWS;
        private string TopicPublish { get; set; }
        private string TopicSubscribe { get; set; }
        public bool IsSubscribe { get; set; }

        public MessagesAws(SettingsAws clientAws, string serialCpu)
        {
            DeviceAWS = clientAws;
            TopicPublish = $"Kiper/Device/Sended/{serialCpu}";
            TopicSubscribe = $"Kiper/Device/Received/{serialCpu}";
            IsSubscribe = false;


            DeviceAWS.Client.MqttMsgSubscribed += IotClient_MqttMsgSubscribed;
            DeviceAWS.Client.MqttMsgPublishReceived += IotClient_MqttMsgPublishReceived;
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
                Console.WriteLine("Não foi possível subscrever no tópico");
                Console.WriteLine("Saindo...");
                Environment.Exit(0);
            }

            while (!IsSubscribe)
            {
            }
        }

        private static void IotClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine("Mensagem recebida: " + Encoding.UTF8.GetString(e.Message));
        }

        private void IotClient_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Console.WriteLine($"Subscrito com sucesso!");
            IsSubscribe = true;
        }
    }
}