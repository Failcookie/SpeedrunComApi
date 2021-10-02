using System.Runtime.Serialization;

namespace SpeedrunComApi.Models.Categories
{
    public enum CategoryType
    {
        [EnumMember(Value = "per-game")]
        PerGame,
        [EnumMember(Value = "per-level")]
        PerLevel
    }
}
