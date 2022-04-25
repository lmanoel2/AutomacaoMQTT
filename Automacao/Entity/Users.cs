using Automacao.Command.Kiper.Params;

namespace Automacao.Entity
{
    public class Users
    {
        public Users ()
        {
        }

        public static object UserManoel()
        {
            User Manoel = new User(userId: 2941,
                userType: 0,
                setRfId: 2,
                secret: "123DWAD4AW",
                openingTime: 8,
                administrator: true,
                validFrom: DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                validUntil: DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                accessCounter: 2,
                restrictAccess: false,
                daysWeek: new DaysWeek(new List<string>() {"08:00-12:00"}));

            return Manoel;
        }
    }
}