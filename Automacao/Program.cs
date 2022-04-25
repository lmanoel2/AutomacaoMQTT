﻿using Automacao.Command.Enum;
using Service.Aws;

using Automacao.Entity.Aws;
using Automacao.Command.Kiper.Params;
using Automacao.Script;
using static Automacao.Command.Kiper.Command;
using static Automacao.Command.Enum.CommandEnum;


//https://hexquote.com/aws-iot-with-net-core-mqtt/

string broker = "a2q2wk17nbok8r-ats.iot.eu-west-1.amazonaws.com";
int port = 8883;
var clientId = "TesteAutomacao";
string certPass = "kiper";
string serialCPU = "105851";
string topicPublish = $"Kiper/Device/Sended/{serialCPU}";
string topicSubscribe = $"Kiper/Device/Received/{serialCPU}";

SettingsAWS clientAws = new();
MessagesAWS device = new(clientAws, "105851");

device.Subscribe();


Ipwall ipwall1 = new Ipwall(506, 1);
Ipwall ipwall2= new Ipwall(508, 1);
Rf rf1 = new Rf(5558874, 50);
Rf rf2 = new Rf(9452875, 1544);

User userManoel = new User( userId: 2941, 
                            userType: 0, 
                            setRfId: 2,
                            secret: "123DWAD4AW", 
                            openingTime: 8, 
                            administrator: true,
                            validFrom: DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                            validUntil: DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), 
                            accessCounter: 2,
                            restrictAccess: false,
                            daysWeek: new DaysWeek(new List<string>(){"08:00-12:00"}),
                            ipwallAccess: new List<Ipwall>(){ipwall1, ipwall2},
                            rfs: new List<Rf>(){rf1, rf2});

SendCommand(INSERT_USER, userManoel, device);

AcessoComTagValida.Execute();

Console.ReadKey();


