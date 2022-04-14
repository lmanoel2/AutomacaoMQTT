using System.Text;

namespace comandos.kiper
{
    class Comandos
    {
        public string Insert_user(List<long> lista_Tags, long id, ushort user_type, DateTime valid_from, DateTime valid_until, int access_counter, List<Dictionary<string, long>> lista_ipwall_access_tag, long user_id, int set_rf_id)
        {
            //------------- Formata a lista de acesso a ipwall -----------
            StringBuilder sbIpwall_access_tag = new StringBuilder();            
            int contDics = 0;
            int contItems = 0;
            sbIpwall_access_tag.Append("[");
            foreach (var dics in lista_ipwall_access_tag)
            {
                contDics++;
                sbIpwall_access_tag.Append("{");
                foreach (KeyValuePair<string, long> item in dics)
                {
                    sbIpwall_access_tag.Append($"\"{item.Key}\": {item.Value}");
                    if (contItems == 0) sbIpwall_access_tag.Append(",");
                    contItems++;
                }
                contItems = 0;
                sbIpwall_access_tag.Append("}");
                if (contDics < lista_ipwall_access_tag.Count) sbIpwall_access_tag.Append(",");
            }
            sbIpwall_access_tag.Append("]");
            //------------------------ Fim ----------------------

            string comando = "{\"cmd\": \"insert_user\", \"id\": " + id + ", \"datetime\": \"" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " \", \"params\":{\"user_id\": " + user_id + ", \"user_type\": ' + str(user_type) + ', \"tag_id\": {"+ String.Join(",", lista_Tags) + "}, \"ipwall_access_tag\":  "+ sbIpwall_access_tag + ", \"set_rf_id\": "+ set_rf_id + ", \"rf\":[{\"rf_id\": 55638271, \"counter_rf\": 563}], \"blocked\": 0, \"opening_time\": 0, \"secret\" : \"5QGXPJHM5TSXHZ64G5R6MNI6W5PI2XDRQVTWDWRDCMTRMES63TJGWRH5SUUEX6V23GGTAECIZKRWEHSTW5M65NWLEZYB3CZAGCO7CSQ\", \"restrict_access\": false, \"days_of_week\": null, \"administrator\" : false, \"valid\":  {\"valid_from\" : "' + str(valid_from) + '", \"valid_until\" : "' + str(valid_until) + '", \"access_counter\": ' + str(access_counter) + '}}} \n";
            return comando;
        }
    }
}
