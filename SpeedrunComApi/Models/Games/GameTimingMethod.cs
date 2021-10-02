using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
