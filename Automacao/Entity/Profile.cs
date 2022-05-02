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
        public User User { get; set; } 
        public UsersEnum ProfileUser { get; set; }

        public Profile(UsersEnum profileUser)
        {
            ProfileUser = profileUser;
            bool status = ChooseProfile(ProfileUser);
            if (!status)
            {
                Console.WriteLine("Perfil de usuario não configurado");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public bool ChooseProfile(UsersEnum profile)
        {
            switch (profile)
            {
                case MANOEL:
                    AssemblyProfileManoel();
                    return true;
                default:
                    Console.WriteLine($"Não encontrado nenhum perfil para o usuário {profile}");
                    return false;
            };
        }

        private void AssemblyProfileManoel()
        {
            //DEVICES
            ListDevice.Add(new Ipwall(181, 1,"172.16.50.181", "KVoice 181"));
            ListDevice.Add(new Ipwall(184, 1, "172.16.50.184", "KVoice 184"));
            
            //TAGS
            ListTags.Add(1234);
            ListTags.Add(55555);
            
            //CONTROLES
            ListRf.Add(new Rf(5558874, 50));
            ListRf.Add(new Rf(99887454, 5770));
            

            User = new User(userId: 2941,
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
                            ipwallAccess: new List<Ipwall>(ListDevice),
                            rfs: new List<Rf>(ListRf),
                            tags: new List<long>(ListTags));
        }
    }
}
