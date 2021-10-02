using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Categories
{
    public enum CategoryPlayerType
    {
        [EnumMember(Value = "exactly")]
        Exactly,
        [EnumMember(Value = "up-to")]
        UpTo
    }
}
