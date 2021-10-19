using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.EnumOptions
{
    public enum RunOrderBy
    {
        [Description("game")]
        Game,
        [Description("category")]
        Category,
        [Description("level")]
        Level,
        [Description("platform")]
        Platform,
        [Description("region")]
        Region,
        [Description("emulated")]
        Emulated,
        [Description("date")]
        Date,
        [Description("submitted")]
        Submitted,
        [Description("status")]
        Status,
        [Description("verify-date")]
        VerifyDate
    }
}
