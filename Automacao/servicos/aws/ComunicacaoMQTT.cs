using entidades.aws;
using System.Text;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace servicos.aws
{
    class ComunicacaoMQTT
    {
        private ConfiguracaoAWS ClientAWS;
        private string TopicPublish;
        private string TopicSubscribe;

        public ComunicacaoMQTT(ConfiguracaoAWS clientAWS, string topicPublish, string topicSubscribe)
        {
            ClientAWS = clientAWS;
            TopicPublish = topicPublish;
            TopicSubscribe = topicSubscribe;
        }

        public void Publish (string mensagem)
        {
            ClientAWS.Client.Publish(TopicPublish, Encoding.UTF8.GetBytes(mensagem));
            Console.WriteLine($"Published: {mensagem}");
        }

        public void Subscribe ()
        {
            var res = ClientAWS.Client.Subscribe(new string[] { TopicSubscribe }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            Console.WriteLine(res);
        }
    }
}
