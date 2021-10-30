using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Runs
{
    public enum RunPlayerRelationOptions
    {
        [EnumMember(Value = "guest")]
        Guest,
        [EnumMember(Value = "user")]
        User
    }
}
