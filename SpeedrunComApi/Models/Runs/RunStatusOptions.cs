
using System.Runtime.Serialization;

namespace SpeedrunComApi.Models.Runs
{
    public enum RunStatusOptions
    {
        [EnumMember(Value = "new")]
        New,
        [EnumMember(Value = "verified")]
        Verified,
        [EnumMember(Value = "rejected")]
        Rejected
    }
}
