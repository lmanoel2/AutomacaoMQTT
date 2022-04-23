using Automacao.Command.Kiper.Requests;
using System.Text.Json;

namespace Automacao.Command.Kiper
{
    class Command
    {
        public static void InsertUser(User user)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
           
            var jsonString = JsonSerializer.Serialize(new InsertUserRequest(user), serializeOptions);

            Console.WriteLine(jsonString);
        }


    }
}
