using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Automacao.Command.Kiper.Params;

public class Ipwall
{
    [JsonPropertyName("ipwall_id")]
    public int IpwallId { get; set; }
    
    [JsonPropertyName("ipwall_name")]
    public string IpwallName { get; set; }
    
    [JsonPropertyName("ip")]
    public string Ip { get; set; }
    
    [JsonPropertyName("disable_emergency")]
    public bool DisableEmergency { get; set; }
    
    [JsonPropertyName("access_type")]
    public string AccessType { get; set; }
    
    [JsonPropertyName("control_doors")]
    public ControlDoors? ControlDoors { get; set; }
    
    [JsonPropertyName("door1_dependency")]
    public List<DoorDependency>? Door1Dependency { get; set; }
    
    [JsonPropertyName("door2_dependency")]
    public List<DoorDependency>? Door2Dependency { get; set; }
    
    [JsonPropertyName("days_of_week")]
    public DaysWeek? DaysOfWeek { get; set; }
    
    [JsonPropertyName("master")]
    public Master? Master { get; set; }
    
    [JsonPropertyName("extern")]
    public bool Extern { get; set; }
    
    [JsonPropertyName("guest_anti_passback")]
    public bool GuestAntiPasback { get; set; }

    public Ipwall(
        int ipwallId, string ipwallName = "", string ip = "", bool disableEmergency = false, string accessType = "", 
        ControlDoors? controlDoors = null, List<DoorDependency>? door1Dependency = null, List<DoorDependency>? door2Dependency = null, 
        DaysWeek? daysOfWeek = null, Master? master = null, bool _extern = false, bool guestAntiPasback = false)
    {
        IpwallId = ipwallId;
        IpwallName = ipwallName;
        Ip = ip;
        DisableEmergency = disableEmergency;
        AccessType = accessType;
        ControlDoors = controlDoors;
        Door1Dependency = door1Dependency;
        Door2Dependency = door2Dependency;
        DaysOfWeek = daysOfWeek;
        Master = master;
        Extern = _extern;
        GuestAntiPasback = guestAntiPasback;
    }
}

public class Master
{
    [JsonPropertyName("ipwall_id")]
    public int IpwallId { get; set; }
    
    [JsonPropertyName("door_id")]
    public int DoorId { get; set; }

    public Master(int ipwallId, int doorId)
    {
        IpwallId = ipwallId;
        DoorId = doorId;
    }

    public Master()
    {
    }
}

public class DoorDependency
{
    [JsonPropertyName("ipwall_id")]
    public int IpwallId { get; set; }
    
    [JsonPropertyName("door_id")]
    public int DoorId { get; set; }

    public DoorDependency(int ipwallId, int doorId)
    {
        IpwallId = ipwallId;
        DoorId = doorId;
    }

    public DoorDependency()
    {
    }
}

public class ControlDoors
{
    [JsonPropertyName("door1")]
    public bool Door1 { get; set; }
    
    [JsonPropertyName("door2")]
    public bool Door2 { get; set; }

    ControlDoors(bool door1, bool door2)
    {
        Door1 = door1;
        Door2 = door2;
    }

    public ControlDoors()
    {
    }
}