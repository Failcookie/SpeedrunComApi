using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Users
{
    public enum UserRole
    {
        [EnumMember(Value = "banned")]
        Banned,
        [EnumMember(Value = "user")]
        User,
        [EnumMember(Value = "trusted")]
        Trusted,
        [EnumMember(Value = "moderator")]
        Moderator,
        [EnumMember(Value = "admin")]
        Admin,
        [EnumMember(Value = "programmer")]
        Programmer
    }
}
