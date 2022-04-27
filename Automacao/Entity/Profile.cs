using Automacao.Command.Enum;
using Automacao.Command.Kiper.Params;
using static Automacao.Command.Enum.UsersEnum;

namespace Automacao.Entity
{
    public class Profile
    {
        public List<Ipwall> ListDevice { get; set; } = new List<Ipwall>();
        public List<long> ListTags { get; set; } = new List<long>();
        public List<Rf> ListRf { get; set; } = new List<Rf>();


        public static User? ChooseProfile(UsersEnum profile)
        {
            switch (profile)
            {
                case MANOEL:
                    return AssemblyProfileManoel();
                default:
                    Console.WriteLine($"Não encontrado nenhum perfil para o usuário {profile}");
                    return null;
            };
        }

        private User AssemblyProfileManoel()
        {            
            ListDevice.Add(new Ipwall(181, 1,"172.16.50.181", "KVoice 181"));
            ListDevice.Add(new Ipwall(184, 1, "172.16.50.184", "KVoice 184"));
            ListTags.Add(1234);
            ListRf.Add(new Rf(5558874, 50));


            Ipwall ipwall181 = new (181, 1, "172.16.50.181", "KVoice 181");
            Ipwall ipwall184 = new (184, 1, "172.16.50.184", "KVoice 184");
            Rf rf1 = new (5558874, 50);
            Rf rf2 = new (9452875, 1544);

            User userManoel = new ( userId: 2941,
                                    userType: 0,
                                    setRfId: 2,
                                    secret: "123DWAD4AW",
                                    openingTime: 8,
                                    administrator: true,
                                    validFrom: DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                    validUntil: DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                    accessCounter: 2,
                                    restrictAccess: false,
                                    daysWeek: new DaysWeek(new List<string>() { "08:00-12:00" }),
                                    ipwallAccess: new List<Ipwall>() { ipwall181, ipwall184 },
                                    rfs: new List<Rf>() { rf1, rf2 });
            return userManoel;
        }
    }
}
