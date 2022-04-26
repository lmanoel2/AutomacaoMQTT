﻿using Automacao.Command.Enum;
using Automacao.Command.Kiper.Params;
using static Automacao.Command.Enum.UsersEnum;

namespace Automacao.Entity
{
    public class Profile
    {
        public void ChooseProfile(UsersEnum profile)
        {
            switch (profile)
            {
                case MANOEL:
                    AssemblyProfileManoel();
                    break;
            };
        }

        public void AssemblyProfileManoel()
        {
            Ipwall ipwall1 = new Ipwall(506, 1);
            Ipwall ipwall2 = new Ipwall(508, 1);
            Rf rf1 = new Rf(5558874, 50);
            Rf rf2 = new Rf(9452875, 1544);

            User userManoel = new User(userId: 2941,
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
                                        ipwallAccess: new List<Ipwall>() { ipwall1, ipwall2 },
                                        rfs: new List<Rf>() { rf1, rf2 });
        }



    }
}
