using System.Runtime.Serialization;

namespace SpeedrunComApi.Models.Games
{
    public enum GameTimingMethod
    {
        [EnumMember(Value = "realtime")]
        Realtime,
        [EnumMember(Value = "realtime_noloads")]
        RealtimeNoloads,
        [EnumMember(Value = "ingame")]
        Ingame
    }
}
