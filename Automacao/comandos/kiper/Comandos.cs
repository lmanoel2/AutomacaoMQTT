using System.Text;
using System.Text.Json;
using Automacao.comandos.kiper;
using Newtonsoft.Json.Linq;

namespace comandos.kiper
{
    class Comandos
    {
        public static void InsertUser(User user)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString =JsonSerializer.Serialize(user, serializeOptions);

            Console.WriteLine(jsonString);
        }

        public string Insert_user(List<long> listaTags, long id, ushort userType, string validFrom, string validUntil, int accessCounter, JArray listaIpwallAccessTag, long userId, int setRfId, JArray listaRfId, int openingTime)
        {

            string sbIpwallAccessTag = FormatarJsonArray(listaIpwallAccessTag);
            string sbRfId = FormatarJsonArray(listaRfId);

            string comando = "{\"cmd\": \"insert_user\", \"id\": " + id + ", \"datetime\": \"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " \", \"params\":{\"user_id\": " + userId + ", \"user_type\": "+userType+", \"tag_id\": ["+ String.Join(",", listaTags) + "], \"ipwall_access_tag\":  "+ sbIpwallAccessTag + ", \"set_rf_id\": "+ setRfId + ", \"rf\": "+ sbRfId + ", \"blocked\": 0, \"opening_time\": "+openingTime+", \"secret\" : \"5QGXPJHM5TSXHZ64G5R6MNI6W5PI2XDRQVTWDWRDCMTRMES63TJGWRH5SUUEX6V23GGTAECIZKRWEHSTW5M65NWLEZYB3CZAGCO7CSQ\", \"restrict_access\": false, \"days_of_week\": null, \"administrator\" : false, \"valid\":  {\"valid_from\" : \" "+validFrom+"\", \"valid_until\" : \""+(validUntil)+ "\", \"access_counter\": "+accessCounter+"}}} \n";
            return comando;
        }


        private string FormatarJsonArray(JArray jArray)
        {
            if (jArray.Count() != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append('[');
                int cont = 0;
                foreach (JToken conteudo in jArray)
                {
                    cont++;
                    sb.Append('{');
                    string conteudoLinhaUnica = string.Join(",", conteudo);
                    sb.Append(conteudoLinhaUnica);
                    sb.Append('}');
                    if (jArray.Count() >= cont+1)
                    {
                        sb.Append(',');
                    }
                }
                sb.Append(']');
                return sb.ToString();
            }
            else
            {
                return "null";
            }
            
        }
    }
}
